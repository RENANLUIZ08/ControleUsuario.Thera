$("#close").on("click", function () {
    $('#user').val("");
    $('#password').val("");

    //default login
    managerBtn(false);
    limparErros();
    limparToken();

    window.location.href = "/Login";
});

function getDashboard(params, maxExpiracao) {
    const cookieOptions = {
        expires: new Date(Date.now() + (maxExpiracao)),
        path: '/'
    };
    document.cookie = `cookieToken=${JSON.stringify(params)};expires=${cookieOptions.expires.toUTCString()};path=${cookieOptions.path}`;
    window.location.href = '/registros/dashboard';
}

function SendTimeSheet(id, operacao, operacaoNome) {
    if (id == 0 && operacao > 0) {
        info("Por Favor, inicie primeiramente o dia em 'CHEGUEI'");
        return;
    }

    if ($("#reg_" + id).length) {
        let trs = [...$("#registros").children('tr')];
        const existeData = trs.some(x => x.children[0].innerHTML === ObterDataAgora());
        if (existeData && $("#reg_" + id).children('td')[operacao + 1].innerHTML != '') {
            info(`Não é permitido realizar a operação de ${operacaoNome}, pois na data do dia ` + $("#reg_" + id).children('td')[operacao].innerHTML + ` ja existe essa operação.`);
            return;
        }

        if ($("#reg_" + id).children('td')[operacao].innerHTML == '') {
            info(`Não é permitido realizar a operação de ${operacaoNome}, pois na data do dia ` + $("#reg_" + id).children('td')[0].innerHTML + ` não foi realizada a operação anterior.`);
            return;
        }
    }

    let registro = {};
    if (operacao > 0) {
        const dataUs = ConverterData($("#reg_" + id).children('td')[0].innerHTML);
        registro = {
            id: id,
            start: `${dataUs} ${$("#reg_" + id).children('td')[1].innerHTML}`,
            startLunch: `${dataUs} ${$("#reg_" + id).children('td')[2].innerHTML}`,
            endLunch: `${dataUs} ${$("#reg_" + id).children('td')[3].innerHTML}`,
            end: `${dataUs} ${$("#reg_" + id).children('td')[4].innerHTML}`
        }
    }

    console.log(registro);

    fetch('/Registros/SendTimeSheet', {
        method: 'POST',
        body: JSON.stringify(
            {
                registroDto: registro,
                type: operacao
            }),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(function (response) {
        if (!response.ok) {
            throw Error(response.statusText);
        }
        return response.json();
    }).then(function (response) {
        if (!response.success) {
            if (response.error) {
                error(response.error);
                return;
            }
            error("Usuario não autenticado.");
            setTimeout(function () {
                window.location.href = '/login'
            }, 2500);
            return;
        }

        success("Hora cadastrada com sucesso!");
        setTimeout(function () {
            window.location.reload();
        }, 1500);

    }).catch(function (err) {
        console.log(err);
    })
}
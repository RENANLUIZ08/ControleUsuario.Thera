$("#frm-login").on("submit", function (evt) {
    evt.preventDefault();
    var username = $('#user').val();
    var password = $('#password').val();
    fazerLogin(username, password);
});

function fazerLogin(username, password) {
    managerBtn(true);
    limparErros();

    fetch('/Login/Index', {
        method: 'POST',
        body: JSON.stringify({
            Usuario: username,
            Senha: password
        }),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(function (response) {
        if (!response.ok) {
            throw Error(response.statusText);
        }
        return response.json();
    }).then(function (result) {
        let obj = result.obj;
        if (obj && obj.length) {
            obj.forEach(item => {
                $(`#error${item.key}`).html(item.error.join(", "));
            });
            managerBtn(false);
            return;
        } else if (result.message) {
            error(result.message);
            managerBtn(false);
            return;
        }

        success(`Bem vindo ${obj.Name}`);
        setTimeout(function () {
            let reload = 10 * 60 * 1000;
            if (!Number.isNaN(reload)) {
                getDashboard(obj, reload);
                setInterval(function () {
                    fazerLogin(username, password);
                }, reload);
            } else {
                error(`erro.`);
            }
        }, 3000);



    }).catch(function (error) {
        console.error(error);
        error(`Erro ao realizar o login, tente novamente.`);
        managerBtn(false);
    });
}
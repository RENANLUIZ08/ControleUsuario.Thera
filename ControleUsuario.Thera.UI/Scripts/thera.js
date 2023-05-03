//toasted default
toastr.options = {
    "closeButton": true,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-bottom-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};

$("#loginButton").on("click", function () {
    /*    toastr.success('Are you the 6 fingered man?');*/
    var username = $('#user').val();
    var password = $('#password').val();
    fazerLogin(username, password);
});

function managerBtn(loading) {
    if (loading) {
        $("#btn-span").css("display", "none");
        $("#spinner").removeAttr("style");
    } else {
        $("#spinner").css("display", "none");
        $("#btn-span").removeAttr("style");
    }
};

function limparErros() {
    $(`#errorusuario`).html();
    $(`#errorsenha`).html();
};

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
            toastr.error(result.message);
            managerBtn(false);
            return;
        }


        toastr.success(`Bem vindo ${obj.Name}`);
        setTimeout(function () {
            let token = obj.TokenType + ' ' + obj.AccessToken;
            let reload = Number.parseInt(obj.ExpiresIn);

            if (!Number.isNaN(reload)) {
                getDashboard(token);
                setTimeout(function () {
                    fazerLogin(username, password);
                }, reload);
            } else {
                toastr.error(`erro.`);
            }
        }, 5000);



    }).catch(function (error) {
        console.error(error);
        toastr.error(`Erro ao realizar o login, tente novamente.`);
        managerBtn(false);
    });
}

function getDashboard(token) {
    var now = new Date();
    var horaExpiracao = new Date(now.getTime() + (1 * 60 * 60 * 1000)); // prazo de validade de 1 hora
    document.cookie = "cookieToken=" + token + "; expires=" + horaExpiracao.toUTCString() + "; path=/registros/dashboard";

    fetch('/registros/dashboard', {
        method: 'GET',
    }).then(response => {
        if (response.ok) {
            // Redireciona para a página de Dashboard se o token for válido
            window.location.href = '/registros/dashboard';
        } else {
            // Redireciona para a página de Login se o token for inválido ou inexistente
            window.location.href = '/login/index';
        }
    })
    .catch(error => {
        console.error('Erro ao chamar o endpoint de Dashboard:', error);
    });
}
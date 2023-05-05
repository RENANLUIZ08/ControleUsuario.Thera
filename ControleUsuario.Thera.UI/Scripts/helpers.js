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

function limparToken() {
    const cookieOptions = {
        expires: new Date(0),
        path: '/'
    };
    document.cookie = `cookieToken=;expires=${cookieOptions.expires.toUTCString()};path=${cookieOptions.path}`;
};
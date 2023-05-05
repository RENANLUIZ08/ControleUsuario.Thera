window.onload = function () {
    const currentDate = $('#current-date');
    const currentTime = $('#current-time');
    updateCurrentTime(currentTime, currentDate);
    setInterval(function () {
        updateCurrentTime(currentTime, currentDate);
    }, 1000);
}


function updateCurrentTime(currentTime, currentDate) {
    const now = new Date();
    const dateString = now.toLocaleDateString();
    const timeString = now.toLocaleTimeString();
    currentTime.html(`${timeString}`);
    currentDate.html(`${dateString}`);
}

function ConverterData(dataBr) {
    if (dataBr === "01-01-0001") return "";

    const partes = dataBr.split("/");
    return `${partes[1]}-${partes[0]}-${partes[2]}`;
}

function ObterDataAgora() {
    const dataAtual = new Date();
    const dia = String(dataAtual.getDate()).padStart(2, '0');
    const mes = String(dataAtual.getMonth() + 1).padStart(2, '0'); // Os meses começam do zero
    const ano = dataAtual.getFullYear();

    return dia + '/' + mes + '/' + ano;
}
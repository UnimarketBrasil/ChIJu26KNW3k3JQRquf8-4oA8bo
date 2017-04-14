function Encripta(dados) {
    var chave = "assbdFbdpdPdpfPdAAdpeoseslsQQEcDDldiVVkadiedkdkLLnm";
    var mensx = "";
    var j = 1;
    for (var i = 0; i < dados.length; i++) {
        mensx += ((((dados.substr(i, 1).charCodeAt(0)) + ((chave.substr(j, 1).charCodeAt(0))))).fromCharCode);
        j++;
    }
    document.getElementById("1").value = mensx;
}
function Descripta(dados) {
    var chave = "assbdFbdpdPdpfPdAAdpeoseslsQQEcDDldiVVkadiedkdkLLnm";
    var mensx = "";
    var j = 1;
    for (var i = 0; i < dados.length; i++) {
        mensx += ((((dados.substr(i, 1).charCodeAt(0)) - ((chave.substr(j, 1).charCodeAt(0))))).fromCharCode);
        j++;
    }
    document.getElementById("1").value = mensx;
}


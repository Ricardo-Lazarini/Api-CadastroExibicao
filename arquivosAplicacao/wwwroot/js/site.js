// Seleção dos elementos
var cep = document.getElementById("cep");
var cepquery = document.getElementById("cepquery");
var nomeCompleto = document.getElementById("nomeCompleto");
var idade = document.getElementById("idade");
var estadoCivil = document.getElementById("estadoCivil");
var carregar = document.getElementById("carregar");
var salvar = document.getElementById("salvar");
var pesquisar = document.getElementById("pesquisar");
var inputs = document.getElementsByTagName("input");
var spans = document.getElementsByTagName("span");
var erroCosultaCidade = document.querySelector(".erroCosultaCidade");


// Eventos

// Captura os valores de nome,idade,estadoCivil e add na localStorage, para ser recuperados após recarregar a pagina de consulta do cep.
// Adiciona os dados do campo cep no formulario de requisição e faz a requisição para a Api ViaCep.
cep.addEventListener("blur", function () {
    cepquery.value = cep.value;
    localStorage.nome = nomeCompleto.value;
    localStorage.idade = idade.value;
    localStorage.estadoCivil = estadoCivil.value;
    pesquisar.click();
})


window.onload = function Carregar() {
    nomeCompleto.value = localStorage.nome;
    idade.value = localStorage.idade;
    estadoCivil.value = localStorage.estadoCivil;
}


salvar.addEventListener("click", function () {
    for (var x = 0; x < inputs.length; x++) {
        if (inputs[x].value === "") {
            inputs[x].value = "Este campo é obrigatório."
            inputs[x].style.border = "solid 1px tomato";
        } else {
            localStorage.clear();
            localStorage.nome = "";
            localStorage.idade = "";
        }
    }
})











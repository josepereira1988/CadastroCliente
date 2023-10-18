const btnEndereco = document.querySelector("#btnEndereco");
const btnExcluirEndereco = document.querySelectorAll(".btnExcluirEndereco");
const campoEndereco = document.querySelectorAll(".campoEndereco");
const campoId = document.querySelector(".campoId");
const btnaddEndereco = document.querySelector("#btnaddEndereco");

btnaddEndereco.addEventListener("click", function () {
    if (validarCampoEndereco()) {
        salvarDados()
    }
});
btnEndereco.addEventListener("click", function () {
    $('#EnderecoModal').modal('show');
});

for (let i = 0; i < campoEndereco.length; i++) {
    const campo = campoEndereco[i];
    if (campo.id != 'Id' && campo.id != 'Complemento') {
        campo.addEventListener('blur', function () {
            if (campo.value != '') {
                campo.classList.remove('campo-invalido');
            } else {
                campo.classList.add('campo-invalido');
            }
        });
    }
};

function validarCampoEndereco() {
    let validar = true
    for (let i = 0; i < campoEndereco.length; i++) {
        const campo = campoEndereco[i];
        if (campo.id != 'Id' && campo.id != 'Complemento') {
            if (campo.value != '') {
                campo.classList.remove('campo-invalido');
            } else {
                campo.classList.add('campo-invalido');
            }
        }

        if (campo.classList.contains('campo-invalido') && validar) {
            validar = false;
        }
    };
    return validar
}

//for (let i = 0; i < btnExcluirEndereco.length; i++) {
//    const btn = btnExcluirEndereco[i];
//    btn.addEventListener('click', function () {
//        excluir(btn.id, btn.nome )
//    });
//};
function excluir(id, idCliente) {
    window.location.href = window.location.protocol + "/Clientes/DeletarEndereco?id=" + id + "&IdCadastro=" + idCliente;
}

function salvarDados() {
    const data = {}
    data["ClienteId"] = campoId.value
    for (let i = 0; i < campoEndereco.length; i++) {
        const campo = campoEndereco[i];
        const id = campo.id;
        const valor = campo.value;

        data[id] = valor;
    };
    const jsonData = JSON.stringify(data);
    console.log(jsonData)
    fetch(window.location.protocol + '/Clientes/cadastroEndereco', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: jsonData
    })
        .then(response => { response.json(); })
        .then(data => {
            alert('Dados enviados com sucesso:');
            window.location.href = window.location.protocol + '/Clientes/Editar/' + campoId.value;
        })
        .catch(error => {
            alert('Erro ao enviar os dados')
            console.error('Erro ao enviar os dados:', error);
        });
}
///// Campo Telefone
const campoTelefone = document.querySelector('.Telefone');

function formatarTelefone(input) {

    const rawValue = input.value.replace(/\D/g, '');

    if (rawValue.length >= 11) {

        const formattedValue = `(${rawValue.substring(0, 2)}) ${rawValue.substring(2, 7)}-${rawValue.substring(7, 11)}`;
        input.value = formattedValue;
    } else if (rawValue.length === 10) {

        const formattedValue = `(${rawValue.substring(0, 2)}) ${rawValue.substring(2, 6)}-${rawValue.substring(6, 10)}`;
        input.value = formattedValue;
    }
    else {

        input.value = rawValue;
    }
}

campoTelefone.addEventListener('input', function () {
    formatarTelefone(this);
});

//// Campo Email
const campoEmail = document.querySelector('.Email');

function validarEmail() {
    const email = campoEmail.value;

    const regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (regex.test(email)) {
        return true;
    } else {
        return false;
    }
}

campoEmail.addEventListener('blur', function () {
    if (validarEmail()) {
        campoEmail.classList.remove('campo-invalido');
    } else {
        campoEmail.classList.add('campo-invalido');
    }
});
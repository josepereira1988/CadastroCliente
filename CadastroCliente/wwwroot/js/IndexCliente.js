const data = {
    Id: 1,
    Name: '',
    DataNacimento: '',
    Telefone: '',
    Email: '',
    Endereco: []
};

function adicionarEnderecosNaTabela(endereco) {
    const corpoTabela = document.getElementById('tbEndeco');

    const newRow = corpoTabela.insertRow(-1);

    //const Id = newRow.insertCell(0);
    const logadouro = newRow.insertCell(0);
    const numero = newRow.insertCell(1);
    const CEP = newRow.insertCell(2);
    
    Id.style.display = 'none';
    //Id.innerHTML = endereco.Id;
    logadouro.innerHTML = endereco.logadouro;
    numero.innerHTML = endereco.numero;
    CEP.innerHTML = endereco.CEP;

}


function abrirmodal(id) {
    if (id === 0) {
        let valor = 'Novo Cadastro'
        camposCadastro[0].value = valor
        $('#CadastroModal').modal('show');
    }
}

function salvarDados() {

    for (let i = 0; i < camposCadastro.length; i++) {
        const campo = camposCadastro[i];
        if (campo.id == "Id") {
            campo.value = 0
        }
        const id = campo.id;
        const valor = campo.value;

        data[id] = valor;
    };
    const jsonData = JSON.stringify(data);
    
    fetch(window.location.href + '/cadastro', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: jsonData
    })
        .then(response => { response.json(); console.log(response.json()); })
        .then(data => {
            alert('Dados enviados com sucesso:');
            window.location.href = window.location.href;
        })
        .catch(error => {
            alert('Erro ao enviar os dados')
            console.error('Erro ao enviar os dados:', error);
        });
}

const btnNovoCadastro = document.querySelector("#btnCadastroNovo");
const modalCliente = document.querySelector('#CrudModal');
const camposCadastro = document.querySelectorAll(".campo");
const camposEndereco = document.querySelectorAll(".campoEndereco");
const btnSalvar = document.querySelector("#btnSalvar");
const btnEndereco = document.querySelector("#btnEndereco");
const btnaddEndereco = document.querySelector("#btnaddEndereco");
const btnExcluir = document.querySelectorAll(".btnExcluir");
const btnExcluirConfirmar = document.querySelector("#btnExcluirConfirmar");
btnExcluirConfirmar.addEventListener('click', function () {
    excluir()
})

for (let i = 0; i < btnExcluir.length; i++) {
    const btn = btnExcluir[i];
    btn.addEventListener('click', function () {
        document.querySelector("#ExcluirId").value = btn.id;
        document.querySelector("#lblExcluir").innerHTML = 'Deseja excluir o cliente "' + btn.name + '"';
        $("#ExcluirModal").modal("show");
    });
};

function excluir() {
    window.location.href = window.location.href + "/deletar?id=" + document.querySelector("#ExcluirId").value
}

for (let i = 0; i < camposCadastro.length; i++) {
    const campo = camposCadastro[i];
    if (campo.id != 'Id') {
        campo.addEventListener('blur', function () {
            if (campo.value != '') {
                campo.classList.remove('campo-invalido');
            } else {
                campo.classList.add('campo-invalido');
            }
        });
    }
};

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

function validarCampo() {
    let validar = true
    for (let i = 0; i < camposCadastro.length; i++) {
        const campo = camposCadastro[i];
        if (campo.id != 'Id') {
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

btnSalvar.addEventListener("click", function () {
    if (validarCampo()) {
       salvarDados()
    }
});


btnNovoCadastro.addEventListener("click", function () {
    data.Endereco = []
    abrirmodal(0)
});

btnEndereco.addEventListener("click", function () {
    for (let i = 0; i < camposEndereco.length; i++) {
        camposEndereco[i].value = "";
    };
    $('#EnderecoModal').modal('show');
});


btnaddEndereco.addEventListener("click", function () {
    if (validarCampoEndereco()) {
        const endereco = {}
        for (let i = 0; i < camposEndereco.length; i++) {
            const campo = camposEndereco[i];
            if (campo.id == "Id") {
                campo.value = '0'
            }
            const id = campo.id;
            const valor = campo.value;

            endereco[id] = valor;
        };
        data.Endereco.push(endereco);
        adicionarEnderecosNaTabela(endereco);
        $('#EnderecoModal').modal('hide');
    }
    
});


///// Campo Telefone
const campoTelefone = document.querySelector('#Telefone');

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
const campoEmail = document.getElementById('Email');

function validarEmail() {
    const campoEmail = document.getElementById('Email');
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


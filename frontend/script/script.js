document.addEventListener('DOMContentLoaded', () => {
    const entradaForm = document.getElementById('entradaForm');
    const saidaForm = document.getElementById('saidaForm');
    const veiculosTableBody = document.getElementById('veiculosTable').getElementsByTagName('tbody')[0];

    entradaForm.addEventListener('submit', async (event) => {
        event.preventDefault();

        const placaInput = document.getElementById('entradaPlaca');
        const placa = placaInput.value.toUpperCase();
        const horaEntra = document.getElementById('entradaHora').value;

        if (!validarPlaca(placa)) {
            alert('A placa deve ter 7 caracteres alfanuméricos.');
            return;
        }

        if (!validarAno2024(horaEntra)) {
            alert('A data e hora de entrada devem ser em 2024.');
            return;
        }

        const veiculo = {
            placa: placa,
            horaEntra: new Date(horaEntra).toISOString()
        };

        try {
            const response = await fetch('https://localhost:7137/api/Veiculo', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(veiculo)
            });

            if (response.ok) {
                alert('Entrada registrada com sucesso!');
                carregarVeiculos();
                entradaForm.reset();
            } else {
                alert('Erro ao registrar entrada!');
            }
        } catch (error) {
            console.error('Erro:', error);
            alert('Erro ao registrar entrada!');
        }
    });

    saidaForm.addEventListener('submit', async (event) => {
        event.preventDefault();

        const placaInput = document.getElementById('saidaPlaca');
        const placa = placaInput.value.toUpperCase();
        const horaSaida = document.getElementById('saidaHora').value;

        if (!validarPlaca(placa)) {
            alert('A placa deve ter 7 caracteres alfanuméricos.');
            return;
        }

        if (!validarAno2024(horaSaida)) {
            alert('A data e hora de saída devem ser em 2024.');
            return;
        }

        const saida = {
            placa: placa,
            horaSaida: new Date(horaSaida).toISOString()
        };

        try {
            const response = await fetch('https://localhost:7137/api/Saidas', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(saida)
            });

            if (response.ok) {
                alert('Saída registrada com sucesso!');
                carregarVeiculos();
                saidaForm.reset();
            } else {
                alert('Erro ao registrar saída!');
            }
        } catch (error) {
            console.error('Erro:', error);
            alert('Erro ao registrar saída!');
        }
    });

    function validarPlaca(placa) {
        return /^[A-Z0-9]{7}$/.test(placa);
    }

    function validarAno2024(data) {
        const ano = new Date(data).getFullYear();
        return ano === 2024;
    }

    async function carregarVeiculos() {
        try {
            const response = await fetch('https://localhost:7137/api/Veiculo');
            const veiculos = await response.json();

            veiculosTableBody.innerHTML = '';

            veiculos.forEach(veiculo => {
                const row = veiculosTableBody.insertRow();

                row.insertCell(0).innerText = veiculo.placa;
                row.insertCell(1).innerText = veiculo.horaEntra ? new Date(veiculo.horaEntra).toLocaleString() : '';
                row.insertCell(2).innerText = veiculo.horaSaida ? new Date(veiculo.horaSaida).toLocaleString() : '';
                row.insertCell(3).innerText = veiculo.tempo ? veiculo.tempo : '';
                row.insertCell(4).innerText = veiculo.valorTotal ? veiculo.valorTotal : '';
            });
        } catch (error) {
            console.error('Erro:', error);
        }
    }

    carregarVeiculos();
});

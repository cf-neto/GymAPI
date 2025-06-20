# Instruções para rodar a API e buscar dados com Fetch

## 1. Rodar a API no terminal

Abra o terminal e navegue até a pasta da API:

```bash
cd GymApp/GymAPI
```

Depois, execute o comando para iniciar a aplicação:

```bash
dotnet run
```

Aguarde até que o servidor informe o endereço onde está rodando, por exemplo:

```
Now listening on: http://localhost:5280
```

## 2. Atualizar o código Fetch com o link correto

Copie o endereço mostrado (exemplo: `http://localhost:5280`) e coloque na função `getAPI` no lugar do URL atual.

Exemplo de função atualizada:

```js
function getAPI()
{
    return fetch('http://localhost:5280/members')  // Substitua pelo endereço correto do seu localhost
    .then(response => {
        if (!response.ok){
            throw new Error("Erro ao buscar os membros");
        }
        return response.json();
    })
    .then(members => {
        members.forEach(member => {
            const tr = document.createElement('tr');
            tr.innerHTML = `
                <td>${member.id}</td>
                <td>${member.name}</td>
                <td>${member.email}</td>
                <td>${new Date(member.birthDate).toLocaleDateString()}</td>
                <td>${member.planId}</td>
            `;
            tbody.appendChild(tr);
        });
    })
    .catch(err => {
        console.error('Erro ao carregar membros:', err);
        tbody.innerHTML = '<tr><td colspan="5">Erro ao carregar membros</td></tr>';
    });
}

document.addEventListener('DOMContentLoaded', () => {
    getAPI();
    sectionHome.classList.add('active');
    trocarSection();
});
```

---

### Observações

- Certifique-se que a API está rodando antes de executar o fetch.
- Atualize o endereço `http://localhost:5280` conforme o que seu terminal exibir ao rodar `dotnet run`.
- O trecho do código `tbody` deve ser previamente definido no seu script, referenciando o elemento `<tbody>` da sua tabela no HTML.
- A função `trocarSection()` e o elemento `sectionHome` devem estar definidos no seu script para funcionar corretamente.

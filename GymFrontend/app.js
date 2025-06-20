const tbody = document.querySelector('#membersTable tbody');

const btnMembers = document.getElementById('h-membros');
const btnPlans = document.getElementById('h-planos');
const btnHome = document.getElementById('h-inicio');

const sectionMembers = document.getElementById('lista-membros');
const sectionPlans = document.getElementById('lista-planos');
const sectionHome = document.getElementById('inicio');


function trocarSection() {
    // Oculta todas
    sectionMembers.style.display = "none";
    sectionPlans.style.display = "none";
    sectionHome.style.display = "none";

    // Exibe só a ativa
    if (sectionMembers.classList.contains('active')) {
        sectionMembers.style.display = "flex";
    } 
    
    else if (sectionPlans.classList.contains('active')) {
        sectionPlans.style.display = "flex";
    } 

    else if (sectionHome.classList.contains('active')) {
        sectionHome.style.display = "flex";
    }
}


// Evento para abrir seção de membros
btnMembers.addEventListener('click', () => {
    sectionPlans.classList.remove('active');
    sectionHome.classList.remove('active');
    sectionMembers.classList.add('active');
    trocarSection();
})

// Evento para abrir seção de planos
btnPlans.addEventListener('click', () => {
    sectionMembers.classList.remove('active');
    sectionHome.classList.remove('active');
    sectionPlans.classList.add('active');
    trocarSection();
})

// Evento para abrir seção da Home
btnHome.addEventListener('click', () => {
    sectionMembers.classList.remove('active');
    sectionPlans.classList.remove('active');
    sectionHome.classList.add('active');
    trocarSection();
})



function getAPI()
{
    return fetch('http://localhost:5280/members')
    .then(response => {
        if (!response.ok){
            throw new Error("Erro");
        }
        return response.json()
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
})
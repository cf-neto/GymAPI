# PROJETO EM DESENVOLVIMENTO ‼️

# 🏋️ GymAPI - API de Gerenciamento de Academia

**GymAPI** é uma API RESTful para gerenciar membros, planos, treinos e check-ins de uma academia.  
Ideal para aprender ASP.NET Core, manipulação de dados, rotas e criação de APIs simples.

---

## ✨ Visão Geral

GymAPI permite que você:

- Cadastre e gerencie membros da academia
- Defina planos de assinatura (mensal, trimestral etc)
- Registre check-ins dos membros
- Liste o histórico de check-ins de cada membro

---

## 📁 Estrutura de Pastas e Arquivos

```plaintext
GymApp/
├── GymAPI/
│   ├── Controllers/
│   │   ├── CheckInController.cs
│   │   ├── MembersController.cs
│   │   └── PlansController.cs
│   ├── Data/
│   │   ├── CheckInRepository.cs
│   │   ├── MemberRepository.cs
│   │   └── PlanRepository.cs
│   ├── Models/
│   │   ├── CheckIn.cs
│   │   ├── Member.cs
│   │   └── Plan.cs
│   ├── Properties/
│   ├── .gitignore
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── GymAPI.csproj
│   └── Program.cs
│
├── GymFrontend/
│   ├── index.html
│   ├── style.css
│   └── app.js
└── README.md
```

## 🚀 Endpoints da API

### Membros (`/members`)
| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/members` | Lista todos os membros |
| GET | `/members/{id}` | Obtém um membro específico |
| POST | `/members` | Cria um novo membro |
| DELETE | `/members/{id}` | Remove um membro |
| PUT | `/members/{id}` | Atualiza um membro |

### Planos (`/plans`)
| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/plans` | Lista todos os planos |
| GET | `/plans/{id}` | Obtém um plano específico |
| POST | `/plans` | Cria um novo plano |
| DELETE | `/plans/{id}` | Remove um plano |

### Check-ins (`/members/{memberId}/checkins`)
| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/members/{memberId}/checkins` | Histórico de check-ins |
| POST | `/members/{memberId}/checkins` | Registra novo check-in |

## 👀 Visualização

![Captura de tela 2025-06-20 204513](https://github.com/user-attachments/assets/9fa88035-5aeb-4a35-8f4c-cd4ea702e32e)




## 📝 Modelos de Dados

### Member
```csharp
public class Member {
  public int Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public DateTime BirthDate { get; set; }
  public int PlanId { get; set; }
}
```

### Plan
```csharp
public class Plan {
  public int Id { get; set; }
  public string Name { get; set; }
  public decimal MonthlyPrice { get; set; }
}
```

### CheckIn
```csharp
public class CheckIn {
  public int Id { get; set; }
  public int MemberId { get; set; }
  public DateTime DateTime { get; set; }
}
```

## ⚙️ Configuração

1. Clone o repositório:
```bash
   git clone https://github.com/cf-neto/GymAPI.git
  ```

2. Restaure as dependências:
```bash
  dotnet restore  
```

3. Acesse a API em:

```bash
http://localhost:{porta}
```


![balta](https://baltaio.blob.core.windows.net/static/images/dark/balta-logo.svg)

![Logo do App](https://github.com/balta-io/desafio-balta-may-the-fourth-backend/assets/965305/880fab7e-3998-4a0d-98ad-1d6ffc11298b)

## 🎖️ Desafio
**May the Fourth** é a quarta edição dos **Desafios .NET** realizados pelo [balta.io](https://balta.io). Durante esta jornada, fizemos parte do batalhão backend onde unimos forças para entregar um App completo.

## 📱 Projeto
Desenvolvimento de uma API completa, fornecendo recursos como criação, leitura, atualização e exclusão de dados referentes ao universo **Star Wars**.

## Participantes
### 🚀 Capitã

| [<img loading="lazy" src="https://avatars.githubusercontent.com/u/55672315?v=4" width=115><br>](https://github.com/danielecastroalves) |
| :---: |
| Daniele Garcia | 
| [![Linkedin](https://img.shields.io/badge/-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/danielegarciadecastroalves/)](https://www.linkedin.com/in/danielegarciadecastroalves/) |
| [![GitHub](https://img.shields.io/badge/-black?style=flat-square&logo=Github&link=https://github.com/danielecastroalves)](https://github.com/danielecastroalves) |

### 💂‍♀️ Batalhão

| [<img loading="lazy" src="https://avatars.githubusercontent.com/u/142629826?s=400&u=39f7bdab59d5e9b2c19de929571401185c10543b&v=4" width=115><br>](https://github.com/Wellington-Climaco) |  [<img loading="lazy" src="https://avatars.githubusercontent.com/u/47541659?v=4" width=115><br>](https://github.com/TheJessicaBohn) |  [<img loading="lazy" src="https://avatars.githubusercontent.com/u/18403104?v=4" width=115><br>](https://github.com/JoseCarlosDaSilva) |
| :---: | :---: | :---: |
| Wellington Clímaco | Jéssica Bohn | José Carlos da Silva |
| [![Linkedin](https://img.shields.io/badge/-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/wellingtonclimaco/)](https://www.linkedin.com/in/wellingtonclimaco/) | [![Linkedin](https://img.shields.io/badge/-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/j%C3%A9ssica-bohn-b93094a1/)](https://www.linkedin.com/in/j%C3%A9ssica-bohn-b93094a1/) | [![Linkedin](https://img.shields.io/badge/-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/josecarlosdasilva/)](https://www.linkedin.com/in/josecarlosdasilva/) |
| [![GitHub](https://img.shields.io/badge/-black?style=flat-square&logo=Github&link=https://github.com/Wellington-Climaco)](https://github.com/Wellington-Climaco) | [![GitHub](https://img.shields.io/badge/-black?style=flat-square&logo=Github&link=https://github.com/TheJessicaBohn)](https://github.com/TheJessicaBohn) | [![GitHub](https://img.shields.io/badge/-black?style=flat-square&logo=Github&link=https://github.com/JoseCarlosDaSilva)](https://github.com/JoseCarlosDaSilva) |


## ⚙️ Tecnologias
* C# 12
* .NET 8
* ASP.NET
* Minimal APIs

## 🥋 Skills Desenvolvidas
* Comunicação
* Trabalho em Equipe
* Networking
* Muito conhecimento técnico

## 🧪 Como testar o projeto

Acesse o link do Swagger: 
```
https://may-the-fourth.azurewebsites.net/swagger/index.html
```
### 📌 EndPoints

- Todas entidades seguem o mesmo padrão de endpoint sendo um GetAll e outro GetById. Exemplo:

  ![image](https://github.com/danielecastroalves/desafio-balta-may-the-fourth-backend/assets/142629826/c0196f72-a614-4378-8143-c13a35066378)

- Os Endpoints do tipo GetAll necessitam dos parametros (page e take) para paginação. Exemplo:
  <img src="https://github.com/danielecastroalves/desafio-balta-may-the-fourth-backend/assets/142629826/6796b880-e420-4047-98ae-bc07a84acab7" width=40% height=40%>


- O retorno dos endpoints também seguem um padrão. Exemplo abaixo de response do endpoint de **GetFilmsAsync**:
```
https://may-the-fourth.azurewebsites.net/api/films?page=1&take=1
```
  Retorno

```json
{
  "total": 6,
  "currentPage": 1,
  "take": 1,
  "result": [
    {
      "title": "A New Hope",
      "episode": "4",
      "openingCrawl": "It is a period of civil war.\r\nRebel spaceships, striking\r\nfrom a hidden base, have won\r\ntheir first victory against\r\nthe evil Galactic Empire.\r\n\r\nDuring the battle, Rebel\r\nspies managed to steal secret\r\nplans to the Empire's\r\nultimate weapon, the DEATH\r\nSTAR, an armored space\r\nstation with enough power\r\nto destroy an entire planet.\r\n\r\nPursued by the Empire's\r\nsinister agents, Princess\r\nLeia races home aboard her\r\nstarship, custodian of the\r\nstolen plans that can save her\r\npeople and restore\r\nfreedom to the galaxy....",
      "director": "George Lucas",
      "producer": "Gary Kurtz, Rick McCallum",
      "releaseDate": "1977-05-25",
      "characters": [
        {
          "id": 1,
          "title": "Luke Skywalker"
        },
        {
          "id": 2,
          "title": "C-3PO"
        }
       ],
       "planets": [
        {
          "id": 1,
          "title": "Tatooine"
        },
        {
          "id": 2,
          "title": "Alderaan"
        }
       ],
       "vehicles": [
        {
          "id": 4,
          "title": "Sand Crawler"
        },
        {
          "id": 6,
          "title": "T-16 skyhopper"
        }
       ],
       "starships": [
        {
          "id": 2,
          "title": "CR90 corvette"
        },
        {
          "id": 3,
          "title": "Star Destroyer"
        }
      ]
    }
  ]
}
```


# 💜 Participe
Quer participar dos próximos desafios? Junte-se a [maior comunidade .NET do Brasil 🇧🇷 💜](https://balta.io/discord)

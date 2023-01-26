<center>
<h1> API - Projeto Radar - Código do Futuro
</center>

<div align="center">

# :computer:  Equipe de DESENVOLVEDORES

</div>

<table align="center">
  <tr>
    <td align="center">
      <a href="https://github.com/GuiHSM">
        <img src="https://avatars.githubusercontent.com/u/18469074?v=4" width="100px;" alt="Foto do Guilherme Marcelino"/><br>
        <sub>
          <b>Guilherme Marcelino</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/Luanftg">
        <img src="https://avatars.githubusercontent.com/u/51548623?v=4" width="100px;" alt="Foto do Luan Fonseca Torralbo Gimenez"/><br>
        <sub>
          <b>Luan F. T. Gimenez</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/bruno-esilva">
        <img src="https://avatars.githubusercontent.com/u/48297443?v=4" width="100px;" alt="Foto do Bruno Silva"/><br>
        <sub>
          <b>Bruno Ernandes da Silva</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/Rfalcao11">
        <img src="https://avatars.githubusercontent.com/u/87043908?v=4" width="100px;" alt="Foto do Rafael Falcão "/><br>
        <sub>
          <b>Rafael Falcão</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/luisedu24">
        <img src="https://avatars.githubusercontent.com/u/117494775?v=4" width="100px;" alt="Foto do Luis Eduardo "/><br>
        <sub>
          <b>Luis Eduardo</b>
        </sub>
      </a>
    </td>
    </tr>
</table>

<hr>

## Desafio

- *Construir uma API para que possamos ter o controle interno sobre as informações de nosso sistema Radar*
- *O sistema será desenvolvido em AspNet core API C#*

### Solução

:star: Modelagem

- Diagrama de Relacionamentos das entidades
![Alt text](abstraction.png)

#### :star: Criação dos EndPoints

- [x] `/principal`
- [x] `/login`
- [x] `/usuarios`
- [x] `/clientes`
- [x] `/enderecos`
- [x] `/lojas`
- [x] `/pedidos`
- [x] `/pedidos-produtos`
- [x] `/posicoes-produtos`

#### :star: Criação dos Serviços

- [x] Autenticação com JWT
- [x] Hash de para armazenar senha criptografada no banco de dados
- [x] `Builder` de instância - *conversor de DTO para a "instância original"*

### Tecnologias Utilizadas

- Entity Framework
- Swagger
- Jose - JWT
- Dotnet CORE 7.0
- Azure

### Referências

- [Desafio Final - Codigo do Futuro](https://docs.google.com/document/d/1z0wzqAeLgMYQFg_jFOTQ1xj_BF1Byo7D/edit)
- [Relações Entity Framework](https://learn.microsoft.com/pt-br/ef/ef6/fundamentals/relationships)

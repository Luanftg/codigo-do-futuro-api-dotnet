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

- **INCLUIR PASSWORD NA STRING DE CONEÃO!**
- Rodar migration para criação do banco:
  - `dotnet ef migrations add MinhaMigracao`
  - `dotnet ef database update`

### Desafio

### Solução

- Diagrama de Relacionamentos das entidades
![Alt text](abstraction.png)

#### :star: Criação dos EndPoints

- [x] `/principal`
- [x] `/login`
- [x] `/usuarios` **Passar para administrador ?**
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
- [ ] Busca de endereço consumindo API VIA CEP  


*Controllers*
- recebe contexto por **injeção de dependência**
  - `builder.Services.AddScoped<>` 'resolvida' em `Program.cs`

### Referências

- [Desafio Final - Codigo do Futuro](https://docs.google.com/document/d/1z0wzqAeLgMYQFg_jFOTQ1xj_BF1Byo7D/edit)
- [Relações Entity Framework](https://learn.microsoft.com/pt-br/ef/ef6/fundamentals/relationships)

#### **Pacotes**

- [SqlServer] (https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)

:star: Ideias para implementar

#### Paginação

```c#
//GET: Pedidos
        public async Task<IActionResult> Index(int page = 1)
        {
            var take = 5;
            var skip = take * (page - 1);

             var marcas =  await Task.FromResult(
                (
                    from marca in _context.Marcas
                    join modelo in _context.Modelos on marca.Id equals modelo.MarcaId into MarcaModeloLeft
                    from subMarcaModelo in MarcaModeloLeft.DefaultIfEmpty()
                    where marca.Nome.Contains("m")
                    select new {
                        Id = marca.Id,
                        Nome = marca.Nome
                    }
                ).Skip(skip).Take(take) // calculado
                // ).Skip(0).Take(5) // pagina 1
                // ).Skip(5).Take(5) // pagina 2
                // ).Skip(10).Take(5) // pagina 3
            );
```

#### Modelo de query para Pedidos

```c#
    // ==== link to sql
            var pedidos =  await Task.FromResult(
                (
                    from ped in _context.Pedidos
                    join cli in _context.Clientes on ped.ClienteId equals cli.Id
                    join car in _context.Carros on ped.CarroId equals car.Id
                    join mod in _context.Modelos on car.ModeloId equals mod.Id
                    join mar in _context.Marcas on mod.MarcaId equals mar.Id
                    select new PedidoResumido {
                        PedidoId = ped.Id,
                        NomeCliente = cli.Nome,
                        NomeCarro = car.Nome,
                        ModeloDoCarro = mod.Nome,
                        MarcaDoCarro = mar.Nome,
                        DataLocacaoPedido = ped.DataLocacao,
                        DataEntregaPedido = ped.DataEntrega
                    }
                )
            );
```

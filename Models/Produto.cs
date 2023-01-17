namespace cdf_api_integrador.Model;

public record Produto
{
    int Id {get;set;}= default!;
    string Nome {get;set;} = default!;
    string Descricao {get;set;} = default!;
    decimal Valor {get;set;} = default!;
    int QtdEstoque {get;set;} = default!;

}
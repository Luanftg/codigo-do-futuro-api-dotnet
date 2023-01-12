public record Endereco
{
    int Id {get;set;}= default!;
    string Cep {get;set;} = default!;
    string Logradouro {get;set;} = default!;
    string Numero {get;set;} = default!;
    string Bairro {get;set;} = default!;
    string Cidade {get;set;} = default!;
    string Estado {get;set;} = default!;
    string Complemento {get;set;} = default!;
}
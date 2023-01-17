public record Cliente
{
    int Id {get;set;} =default!;
    string Nome {get;set;} = default!;
    string Telefone {get;set;} = default!;
    string Email {get;set;} = default!;
    string Cpf {get;set;} = default!;
    string Endereco_Id {get;set;} = default!;
}
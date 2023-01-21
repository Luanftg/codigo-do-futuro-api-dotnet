using System.ComponentModel.DataAnnotations;

namespace cdf_api_integrador.Models;

public record Cliente
{
    [Key]
    public int Id {get;set;} =default!;
    public string Nome {get;set;} = default!;
    public string Telefone {get;set;} = default!;
    public string Email {get;set;} = default!;
    public string Cpf {get;set;} = default!;
    public int EnderecoId {get;set;}= default!;
    public Endereco? Endereco {get;set;}
}
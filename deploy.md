# Script para deploy das aplicações

## Acesso a Núvem - [Azure](https://azure.microsoft.com/pt-br/free/search/?OCID=AIDcmmzmnb0182_SEM_e9d4fa3c50ce1c51612699f3a66435a2:G:s&ef_id=e9d4fa3c50ce1c51612699f3a66435a2:G:s&msclkid=e9d4fa3c50ce1c51612699f3a66435a2)

### Chave SSH

1. Liberação
   1. `chmod 400 <path do arquivo que contem a  sua chave: *.pem>`
2. Acesso - Protocolo SSH
   1. `ssh -i <path do arquivo que contem a  sua chave: *.pem> <user:azureuser>@<IP público>`
   2. **Primeiro acesso** - Atualizar referencias de pacotes e versões
      1. Acessar como admin no diretório `root`
         1. `sudo su -`
         2. `apt update`
         3. `apt upgrade`
3. Instalar o Servidor - Nginx
   1. `apt install nginx`
   2. Liberação de Firewall na núvem-(inbound rules)
      1. incluir regra de entrada para a porta 80 (http service) em *Networking - Add inbound security rule*
      2. Agora o iP público na porta 80 da acesso ao servidor Nginx.
4. Configuração
   1. *config nginx path linux - busca*
   2. `cat / etc/nginx/sites-available/default`
      1. `root/var/www/html/index.nginx-debian.html` - index html inicial padrão do nginx
   3. `vim etc/nginx/sites-available/default`
      1. `Insert` `w` - salva `q` sair
5. Build do projeto **Angular**
   1. `ng build` do projeto FrontEnd: gera na pasta *dist* o diretorio compilado com o html do projeto Angular.
6. Upload dos diretórios na núvem - Protocolo scp para transferência de dados
   1. Transfere um diretório:  ``scp -r -i <chave> <diretorio a ser transferido> <user>@<IP Público>: home/azureuser``
      1. Pode mandar um arquivo Zipado tambem: sem a tag `- r` e instalar o unzip.
7. Move o diretório para o usuário root:
   1. `sudo mv <diretorio a ser transferido> /root/`
8. Remove o arquivo *index* padrão do nginx
   1. `rm -rf var/www/html/index.nginx-debian.html`
9.  Mover o diretório para a pasta *html*
   1. `mv <diretorio/*> /var/www/html`

### Qualquer Servidor com VPS ( que abra uma porta) - Configuração da API no Servidor

1. Clone do repositório público da Api
   1. `git clone <clone do repositorio>`  
2. Instalação do sdk dotnet [Microsoft - Install sdk Dotnet Ubuntu](https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#2210)

```
wget https://packages.microsoft.com/config/ubuntu/22.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt-get update && \
sudo apt-get install -y dotnet-sdk-7.0
```

3. Validação da sintaxe:  `dotnet build`
4. Publicação da API (produção) - `dotnet publish -o Release`
5. `dotnet <arquivo.dll>`
6. Configurar o Nginx para estratégia de **ProxyPass**
7. Startar o servidor em background : `nohup dotnet <arquivo>.dll &`
   1. `tail -f nohup.out` : exibe os logs
   2. `lsof -i:5000`: exibe o PID das portas que estão sendo ouvidas pelo servidor
   3. `kill -9 PID`: derruba a aplicação
8. Entra no arquivo de config do nginx: 
   1. `vim etc/nginx/sites-available/default`

```
    location / {
        proxy_pass http://localhost:5000;
}
```
``Esc : wq`` - salva e sai do arquivo

### Estratégia do API Gateway

```
upstream csharp {
    server localhost:5000;
}

server {
    root /var/www/html/;

    index index.html index.htm index.nginx-debian.html;

    server_name  azure-front.luanftg.com.br;

    location / {
            try_files $uri $uri/ =404;
    }
}

server {
    proxy_set_header   X-Forwarded-For $remote_addr;
    proxy_set_header   Host $http_host;
    proxy_connect_timeout 30s;
    proxy_read_timeout 30s;

    server_name  azure-api.luanftg.com.br;

    # consigo acessar / ou /clientes da api feita com os alunos: git@github.com:torneseumprogramador/api-codigo-do-futuro.git
    location ~ ^/(.*)  {
        proxy_pass http://csharp;
    }
}

```

[Repositório Danilo - nginx](https://github.com/torneseumprogramador/nginx-config/blob/main/8-nginx-api-gateway/nginx-proxy_pass-api-gateway-regex-route-path)

```
upstream nodejs {
    server 10.0.0.4:30000;
}

upstream csharp {
    server 10.0.0.4:30001;
}

server {
    proxy_set_header   X-Forwarded-For $remote_addr;
    proxy_set_header   Host $http_host;
    proxy_connect_timeout 300s;
    proxy_read_timeout 300s;
    
    location ~ ^/csharp/(.*) {
        proxy_pass http://csharp/;
    }

    location ~ ^/nodejs/(.*) {
        proxy_pass http://nodejs/;
    }
}
```

[Repositório - estratégia regex por path](https://github.com/torneseumprogramador/nginx-config/blob/main/8-nginx-api-gateway/nginx-config-path)

ssh -i codigo-do-futuro-azure-key.pem azureuser@172.174.154.130

scp -r -i codigo-do-futuro-azure-key.pem C:\exercicio-angular-cf azureuser@172.174.154.130:/home/azureuser

# socialarts.club

Initital setup:

* Registrar: Namespro.ca with 2 custom name servers.
* Nameservers: Cloudflare 
  * `www` and `@` A records pointing to Azure
  * `autodiscover` and `@` CNAME and MX records pointing to MSFT Exchange.
* SSL certificate: Cloudflare
* Custom Email: Office 365 
* Web Hosting: Azure App Service with continuous deployment from GitHub.
* Web App: ASP.NET Core MVC with Razor Pages and Bootstrap 4.
* Version Control: Git and GitHub

Valuable resources: 

* https://html.spec.whatwg.org/dev
* https://owl.purdue.edu/owl/research_and_citation/apa_style/apa_formatting_and_style_guide/general_format.html
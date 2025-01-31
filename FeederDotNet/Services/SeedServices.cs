
using FeederDotNet.DAL;
using FeederDotNet.Models;

namespace FeederDotNet.Services
{
    public class SeedServices : ISeedServices
    {

        private readonly IDataSetRepository datasetRepository;
        private readonly ICrawlerServices crawlerServices;


        public SeedServices(IDataSetRepository _datasetRepository, ICrawlerServices _crawlerServices) { 
            datasetRepository = _datasetRepository;
            crawlerServices = _crawlerServices;
        }

        public async Task Execute()
        {

            List<Dataset> datasets = new List<Dataset>();

            datasets.Add(new Dataset { Url = "https://www.lance.com.br/onde-assistir/brasil-x-colombia-onde-assistir-horario-e-escalacoes-pelo-sul-americano-sub-20.html", Classification = "Soccer" });
            datasets.Add(new Dataset { Url = "https://www.lance.com.br/flamengo/flamengo-divulga-relacionados-para-supercopa-rei-com-uma-ausencia-e-uma-novidade.html", Classification = "Soccer" });
            datasets.Add(new Dataset { Url = "https://www.lance.com.br/flamengo/flamengo-oficializa-emprestimo-de-alcaraz-para-time-da-premier-league-2.html", Classification = "Soccer" });
            datasets.Add(new Dataset { Url = "https://www.lance.com.br/flamengo/flamengo-divulga-relacionados-para-supercopa-rei-com-uma-ausencia-e-uma-novidade.html", Classification = "Soccer" });
            datasets.Add(new Dataset { Url = "https://www.lance.com.br/lancebiz/o-que-tinha-na-caixa-que-neymar-recebeu-ao-descer-do-aviao.html", Classification = "Soccer" });
            datasets.Add(new Dataset { Url = "https://girodociclismo.com.br/remco-evenepoel-foi-feito-para-o-tour-de-france-diretor-da-soudal-revela-sua-confianca-na-vitoria-do-campeao-mundial-de-contrarrelogio/", Classification = "Ciclismo" });
            datasets.Add(new Dataset { Url = "https://girodociclismo.com.br/egan-bernal-quebra-de-recorde-de-iconica-montanha-na-colombia-apos-treino-assista-o-video/", Classification = "Ciclismo" });
            datasets.Add(new Dataset { Url = "https://girodociclismo.com.br/tom-pidcock-vence-4a-etapa-do-alula-tour-e-amplia-lideranca-confira-os-resultados-e-a-chegada/", Classification = "Ciclismo" });
            datasets.Add(new Dataset { Url = "https://girodociclismo.com.br/campeonato-mundial-de-ciclismo-pode-mudar-de-local-uci-prepara-plano-b-devido-a-violencia-no-congo/", Classification = "Ciclismo" });

            foreach (var dataset in datasets) {
                Models.Article article = await crawlerServices.Execute(dataset.Url);
                dataset.Text = article.TextContent;
                await datasetRepository.AddAsync(dataset);
            }

        }
    }
}

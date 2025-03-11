
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

        public List<Dataset> getAllSources() {

            List<Dataset> datasets = new List<Dataset>();

            datasets.Add(new Dataset { Url = "https://www.lance.com.br/onde-assistir/brasil-x-colombia-onde-assistir-horario-e-escalacoes-pelo-sul-americano-sub-20.html", Classification = "Futebol" });
            datasets.Add(new Dataset { Url = "https://www.lance.com.br/flamengo/flamengo-divulga-relacionados-para-supercopa-rei-com-uma-ausencia-e-uma-novidade.html", Classification = "Futebol" });
            datasets.Add(new Dataset { Url = "https://www.lance.com.br/flamengo/flamengo-oficializa-emprestimo-de-alcaraz-para-time-da-premier-league-2.html", Classification = "Futebol" });
            datasets.Add(new Dataset { Url = "https://www.lance.com.br/flamengo/flamengo-divulga-relacionados-para-supercopa-rei-com-uma-ausencia-e-uma-novidade.html", Classification = "Futebol" });
            datasets.Add(new Dataset { Url = "https://www.lance.com.br/lancebiz/o-que-tinha-na-caixa-que-neymar-recebeu-ao-descer-do-aviao.html", Classification = "Futebol" });
            datasets.Add(new Dataset { Url = "https://ge.globo.com/mg/triangulo-mineiro/futebol/noticia/2025/02/04/conheca-o-jovem-ex-atletico-mg-e-flu-que-sonha-com-selecao-dos-emirados-arabes.ghtml", Classification = "Futebol" });
            datasets.Add(new Dataset { Url = "https://ge.globo.com/futebol/times/atletico-mg/noticia/2025/02/04/atletico-mg-hulk-tem-novo-passo-por-500-gols-na-carreira-em-estadio-que-mais-marcou.ghtml", Classification = "" });


            datasets.Add(new Dataset { Url = "https://girodociclismo.com.br/remco-evenepoel-foi-feito-para-o-tour-de-france-diretor-da-soudal-revela-sua-confianca-na-vitoria-do-campeao-mundial-de-contrarrelogio/", Classification = "Ciclismo" });
            datasets.Add(new Dataset { Url = "https://girodociclismo.com.br/egan-bernal-quebra-de-recorde-de-iconica-montanha-na-colombia-apos-treino-assista-o-video/", Classification = "Ciclismo" });
            datasets.Add(new Dataset { Url = "https://girodociclismo.com.br/tom-pidcock-vence-4a-etapa-do-alula-tour-e-amplia-lideranca-confira-os-resultados-e-a-chegada/", Classification = "Ciclismo" });
            datasets.Add(new Dataset { Url = "https://girodociclismo.com.br/campeonato-mundial-de-ciclismo-pode-mudar-de-local-uci-prepara-plano-b-devido-a-violencia-no-congo/", Classification = "Ciclismo" });

            

            datasets.Add(new Dataset { Url = "https://ge.globo.com/basquete/nba/noticia/2025/02/04/nba-atendimento-medico-a-torcedor-choca-jogadores-antes-de-memphis-grizzlies-e-san-antonio-spurs-video.ghtml", Classification = "Basquete" });


            datasets.Add(new Dataset { Url = "https://ge.globo.com/combate/noticia/2025/02/04/rafael-cordeiro-tecnico-de-mike-tyson-rechaca-luta-armada-com-jake-paul.ghtml", Classification = "Combate" });
            datasets.Add(new Dataset { Url = "https://ge.globo.com/combate/noticia/2025/02/03/papo-cruzado-murilo-bustamante-analisa-a-pratica-do-trash-talk-no-mundo-da-luta.ghtml", Classification = "Combate" });
            datasets.Add(new Dataset { Url = "https://ge.globo.com/combate/noticia/2025/02/02/adesanya-desabafa-apos-derrota-no-ufc-odeio-decepcionar-meus-fas-e-minha-equipe.ghtml", Classification = "Combate" });
            datasets.Add(new Dataset { Url = "https://ge.globo.com/combate/noticia/2025/02/03/popo-freitas-comemora-vitoria-de-iago-no-fms-e-afirma-pode-entregar-muito-mais.ghtml", Classification = "Combate" });
            datasets.Add(new Dataset { Url = "https://ge.globo.com/combate/noticia/2025/02/04/rafael-cordeiro-tecnico-de-mike-tyson-rechaca-luta-armada-com-jake-paul.ghtml", Classification = "Combate" });
            datasets.Add(new Dataset { Url = "https://ge.globo.com/ac/noticia/2025/02/03/lutador-acreano-embarca-para-disputar-cinturao-do-aec-mma-league-em-paris.ghtml", Classification = "Combate" });
            datasets.Add(new Dataset { Url = "https://ge.globo.com/sp/santos-e-regiao/noticia/2025/02/03/bruna-brasil-volta-a-lutar-pelo-ufc-em-sidney-na-australia.ghtml", Classification = "Combate" });
            datasets.Add(new Dataset { Url = "https://ge.globo.com/combate/noticia/2025/02/02/fms-em-luta-prejudicada-pela-chuva-filho-de-popo-vence-duelo-apertado.ghtml", Classification = "Combate" });

            //datasets.Add(new Dataset { Url = "", Classification = "" });

            return datasets;
        }

        public async Task Execute()
        {

            List<Dataset> datasets = getAllSources();

            foreach (var dataset in datasets) {
                Models.Article article = await crawlerServices.Execute(dataset.Url);
                dataset.Text = article.TextContent;
                await datasetRepository.AddAsync(dataset);
            }

        }
    }
}

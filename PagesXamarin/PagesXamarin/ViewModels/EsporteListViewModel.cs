using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PagesXamarin.Models;
using PagesXamarin.Utilities;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace PagesXamarin.ViewModels
{
    public class EsporteListViewModel : ViewModelBase
    {
        #region Variaveis


        private bool _isOpenList = false;
        public virtual bool IsOpenList
        {
            get => _isOpenList;
            set { SetProperty(ref _isOpenList, value); }
        }

        //public Esporte Esporte { get; set; }
        Esporte sport;
        public Esporte Sport
        {
            get { return sport; }
            set { SetProperty(ref sport, value); }
        }

        List<Esporte> sportList;
        public List<Esporte> SportList
        {
            get { return sportList; }
            set { SetProperty(ref sportList, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string nameAluno;
        public string NameAluno
        {
            get { return nameAluno; }
            set { SetProperty(ref nameAluno, value); }
        }

        private string _inicialName;
        public string InicialName
        {
            get { return _inicialName; }
            set { SetProperty(ref _inicialName, value); }
        }

        private string nameResponsavel;
        public string NameResponsanvel
        {
            get { return nameResponsavel; }
            set { SetProperty(ref nameResponsavel, value); }
        }
        private string dataNiver;
        public string DataNiver
        {
            get { return dataNiver; }
            set { SetProperty(ref dataNiver, value); }
        }

        private string celResponsavel;
        public string CelResponsavel
        {
            get { return celResponsavel; }
            set { SetProperty(ref celResponsavel, value); }
        }

        private Aluno aluno;
        public Aluno Aluno
        {
            get { return aluno; }
            set { SetProperty(ref aluno, value); }
        }

        List<Aluno> _listAlunos;
        public List<Aluno> ListAluno
        {
            get { return _listAlunos; }
            set { SetProperty(ref _listAlunos, value); }
        }

        List<Aluno> _fakeList;
        public List<Aluno> RepositoryList
        {
            get { return _fakeList; }
            set { SetProperty(ref _fakeList, value); }
        }

        List<Esporte> _alunoSportList;
        public List<Esporte> AlunoSportList
        {
            get { return _alunoSportList; }
            set { SetProperty(ref _alunoSportList, value); }
        }

        #endregion

        public EsporteListViewModel()
        {
            SportList = new List<Esporte>();
            ListAluno = new List<Aluno>();
            RepositoryList = new List<Aluno>();
            AlunoSportList = new List<Esporte>();
            Name = "Gustavo Nielsen";
            Email = "gusanielsen@gmail.com";
            InicialName = RegexUtilities.ExtractInitialsFromName(Name);
            _taskInit = TaskInit();
            
        }


        private async Task TaskInit()
        {
            await MetodoReposytory();
            await LoadList();
        }

        private async Task LoadList()
        {
            if (RepositoryList.Count ==0)
            {
                return;
            }
            foreach (var item in RepositoryList)
            {
                ListAluno.Add(item);
            }

            // Ordenando ALFABÉTCAMENTE
            ListAluno = ListAluno.OrderBy(x => x.NameAluno).ToList();
            IsOpenList = true;
            RepositoryList.Clear();
        }

        private async Task MetodoReposytory()
        {
            #region Futebol 
            var Futebol = new Esporte();
            Futebol.Name = "Futebol";
            Futebol.Image = "futbol.png";
            SportList.Add(Futebol);
            #endregion

            #region Basquete
            var Basquete = new Esporte();
            Basquete.Name = "Basquete";
            Basquete.Image = "basketball.png";
            SportList.Add(Basquete);
            #endregion

            #region tennis
            var Tennis = new Esporte();
            Tennis.Name = "Tenis";
            Tennis.Image = "tennis.png";
            SportList.Add(Tennis);
            #endregion

            #region Canoagem
            var Canoagem = new Esporte();
            Canoagem.Name = "Canoagem";
            Canoagem.Image = "canoe.png";
            SportList.Add(Canoagem);
            #endregion

            #region Boxe
            var Boxe = new Esporte();
            Boxe.Name = "Boxe";
            Boxe.Image = "boxing.png";
            SportList.Add(Boxe);
            #endregion

            #region Natação
            var Natacao = new Esporte();
            Natacao.Name = "Natação";
            Natacao.Image = "natacao.png";
            SportList.Add(Natacao);
            #endregion

            #region Futebol Americanoo
            var Futebol_Amaricano = new Esporte();
            Futebol_Amaricano.Name = "Futebol Americano";
            Futebol_Amaricano.Image = "american_football.png";
            SportList.Add(Futebol_Amaricano);
            #endregion

            #region Baseball
            var Baseball = new Esporte();
            Baseball.Name = "Baseball";
            Baseball.Image = "baseball.png";
            SportList.Add(Baseball);
            #endregion
        }

        #region Commands
        private DelegateCommand<Esporte> _sportSelectedCommand;         public DelegateCommand<Esporte> SportSelectedCommand => _sportSelectedCommand ?? (_sportSelectedCommand = new DelegateCommand<Esporte>(async (item) => await SportSelectedAsync(item)));
        /// <summary>
        /// SportSelectedAsync
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private async Task SportSelectedAsync(Esporte item)
        {
            IsBusy = true;
            
        }
        private DelegateCommand _saveItemCommand;
        public DelegateCommand SaveItemCommand => _saveItemCommand ?? (_saveItemCommand = new DelegateCommand(async () => await SaveSelectedAsync()));

        /// <summary>
        /// SaveSelectedAsync
        /// </summary>
        /// <returns></returns>
        private async Task SaveSelectedAsync()
        {
            Aluno = new Aluno();
            Aluno.NameAluno = NameAluno;
            Aluno.NameResponsanvel = NameResponsanvel;
            Aluno.DataNiver = DataNiver;
            Aluno.CelResponsavel = CelResponsavel;
            Aluno.InicialName = RegexUtilities.ExtractInitialsFromName(NameAluno);
            RepositoryList.Add(Aluno);
            IsBusy = false;
            NameAluno = null;
            NameResponsanvel = null;
            DataNiver = null;
            CelResponsavel = null;
          await  LoadList();
        }
        #endregion
    }
}

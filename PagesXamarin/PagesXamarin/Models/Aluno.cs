using System;
using Newtonsoft.Json;

namespace PagesXamarin.Models
{
    public class Aluno
    {
        [JsonProperty(PropertyName = "namealuno")]
        public string NameAluno { get; set; }
        [JsonProperty(PropertyName = "nameresponsavel")]
        public string NameResponsanvel { get; set; }
        [JsonProperty(PropertyName = "dataniver")]
        public string DataNiver { get; set; }
        [JsonProperty(PropertyName = "celresponsavel")]
        public string CelResponsavel { get; set; }
        [JsonProperty(PropertyName = "inicialname")]
        public string InicialName { get; set; }
        public Aluno()
        {
        }
    }
}

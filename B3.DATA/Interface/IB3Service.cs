using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static B3.DATA.Model.ListarTodasAcoesModel;
using static B3.DATA.Model.ListarTodosFiisModel;

namespace B3.DATA.Interface
{
    public interface IB3Service
    {
        Task<Acoes> ListarTodasAcoes();
        //Fiis ListarTodosFiis();
        Task<Fiis> ListarTodosFiis();
    }
}

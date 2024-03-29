﻿using ControleUsuario.Thera.Domain.DTO;
using ControleUsuario.Thera.Service.Resources.Response;
using ControleUsuario.Thera.Service.Resources.Response.TimeSheetModels;
using Domain.Thera.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Service.Interface
{
    public interface IRegistroService
    {
        Task<TimeSheetCreated> CreateTimeSheet(AutenticacaoDto autenticacao);
        Task<string> UpdateTimeSheet(AutenticacaoDto autenticacao, RegistroDto registroDto, ETimeSheet eTimeSheet);
        Task<List<RegistroDto>> GetAllTimeSheets(AutenticacaoDto autenticacao);
    }
}

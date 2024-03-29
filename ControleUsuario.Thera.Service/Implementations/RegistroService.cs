﻿using AutoMapper;
using ControleUsuario.Thera.Domain.DTO;
using ControleUsuario.Thera.Domain.Entidades;
using ControleUsuario.Thera.Service.Interface;
using ControleUsuario.Thera.Service.Resources.Requested;
using ControleUsuario.Thera.Service.Resources;
using Domain.Thera.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleUsuario.Thera.Service.Resources.Response.TimeSheetModels;
using Newtonsoft.Json.Linq;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using ControleUsuario.Thera.Service.Resources.Requested.TimeSheetModels;
using Microsoft.Win32;
using ControleUsuario.Thera.Service.Resources.Response;

namespace ControleUsuario.Thera.Service.Implementations
{
    public class RegistroService : ServiceBase<RegistroService>, IRegistroService
    {
        private readonly string route = "Timesheet";
        public RegistroService(
            IMapper mapper) : base(mapper)
        {

        }

        public async Task<TimeSheetCreated> CreateTimeSheet(AutenticacaoDto autenticacao)
        {
            using (var request = new RequestBase(autenticacao.TokenType, autenticacao.AccessToken))
            {
                try
                {
                    request.SetRoute(Constants.TheraUrl, route);
                    var response = await request.PostAsync<TimeSheetCreated>();
                    return response;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<string> UpdateTimeSheet(AutenticacaoDto autenticacao, RegistroDto registroDto, ETimeSheet eTimeSheet)
        {
            var registro = _mapper.Map<Registro>(registroDto);
            using (var request = new RequestBase(autenticacao.TokenType, autenticacao.AccessToken))
            {
                switch (eTimeSheet)
                {
                    case ETimeSheet.Start:
                        throw new ArgumentException("Ops, essa operação é invalida pois o dia ja foi inicializado.");
                    case ETimeSheet.LuchStart:
                        registro.IniciarAlmoco();
                        break;
                    case ETimeSheet.EndStart:
                        registro.FinalizarAlmoco();
                        break;
                    case ETimeSheet.End:
                        registro.FinalizarExpediente();
                        break;
                    default:
                        throw new ArgumentException("Ops, não foi identificado o tipo de opção correspondente.");
                }


                try
                {
                    request.SetRoute(Constants.TheraUrl, route);
                    _ = await request.PutAsync<string>(param: $"/{registro.Id}", _mapper.Map<PutTimeSheet>(registro));
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return await Task.FromResult(registroDto.TotalDay);
            }

        }

        public async Task<List<RegistroDto>> GetAllTimeSheets(AutenticacaoDto autenticacao)
        {
            using (var request = new RequestBase(autenticacao.TokenType, autenticacao.AccessToken))
            {
                try
                {
                    request.SetRoute(Constants.TheraUrl, route);
                    var response = await request.GetAsync<Paginacao>();

                    if ((response?.Items?.Count).GetValueOrDefault(0) > 0)
                    {
                        return response.Items.Select(r =>
                        {
                            var getRegistro = _mapper.Map<Registro>(r);
                            return _mapper.Map<RegistroDto>(getRegistro);
                        }).AsParallel().ToList();
                    }

                    return new List<RegistroDto>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}

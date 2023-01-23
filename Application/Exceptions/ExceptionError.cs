using Microsoft.AspNetCore;
using Application.Contracts.IUOW;
using Application.Contracts.Persistence;
using AutoMapper;
using System;
using System.Collections.Generic;
using MediatR;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Exceptions
{
    public class ExceptionError
    {

        //  ApplicationDbContext

        public void Error(string Message, string InnerException, string action, string controller, string StackTrace)
        {

            DatabaseLog databaseLog = new DatabaseLog();
            databaseLog.Error = Message;
            databaseLog.InnerException = InnerException;
            databaseLog.ActionName = action;
            databaseLog.ControllerName = controller;
            databaseLog.StackTrace = StackTrace;
            databaseLog.CreatedBy = "";
            databaseLog.ExternalRequest = "";
            databaseLog.ExternalResponse = "";
            databaseLog.Request = "";
            databaseLog.Response = "";

            try
            {


            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}

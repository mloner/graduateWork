using System;
using System.Net.Http;
using EcoSCADA.Common.ExceptionHandling.Abstraction;
using EcoSCADA.Common.ExceptionHandling.Abstraction.Exceptions;
using EcoSCADA.Common.ExceptionHandling.ExceptionMappers;
using EcoSCADA.Common.ExceptionHandling.Models;
using Polly.Timeout;

namespace EcoSCADA.Common.ExceptionHandling
{
    internal class ExceptionToResponseMapper: IExceptionToResponseMapper
    {
        private readonly DomainExceptionMapper _domainExceptionMapper;
        private readonly UnhandledExceptionMapper _unhandledExceptionMapper;
        private readonly NotFoundExceptionMapper _notFoundExceptionMapper;
        private readonly UnprocessableEntityExceptionMapper _unprocessableEntityExceptionMapper;
        private readonly ArgumentExceptionMapper _argumentExceptionMapper;
        private readonly ArgumentNullExceptionMapper _argumentNullExceptionMapper;
        private readonly AggregateExceptionMapper _aggregateExceptionMapper;
        private readonly HttpRequestExceptionMapper _requestExceptionMapper;
        private readonly TimeoutRejectedExceptionMapper _timeoutRejectedExceptionMapper;

        public ExceptionToResponseMapper(
            DomainExceptionMapper domainExceptionMapper, 
            UnhandledExceptionMapper unhandledExceptionMapper,
            NotFoundExceptionMapper notFoundExceptionMapper,
            UnprocessableEntityExceptionMapper unprocessableEntityExceptionMapper,
            ArgumentExceptionMapper argumentExceptionMapper,
            ArgumentNullExceptionMapper argumentNullExceptionMapper,
            AggregateExceptionMapper aggregateExceptionMapper,
            HttpRequestExceptionMapper requestExceptionMapper,
            TimeoutRejectedExceptionMapper timeoutRejectedExceptionMapper
            )
        {
            _domainExceptionMapper = domainExceptionMapper;
            _unhandledExceptionMapper = unhandledExceptionMapper;
            _notFoundExceptionMapper = notFoundExceptionMapper;
            _unprocessableEntityExceptionMapper = unprocessableEntityExceptionMapper;
            _argumentExceptionMapper = argumentExceptionMapper;
            _argumentNullExceptionMapper = argumentNullExceptionMapper;
            _aggregateExceptionMapper = aggregateExceptionMapper;
            _requestExceptionMapper = requestExceptionMapper;
            _timeoutRejectedExceptionMapper = timeoutRejectedExceptionMapper;
        }
        
        //From most detailed exception to most generic one. 
       public ExceptionResponse Map(Exception exception, ProblemDetailsExtensions extensions) => exception switch
        {
            DomainException ex => _domainExceptionMapper.SetDomainExceptionResponse(ex, extensions),
            NotFoundException ex => _notFoundExceptionMapper.SetNotFoundExceptionResponse(ex, extensions),
            UnprocessableEntityException ex => _unprocessableEntityExceptionMapper.SetUnprocessableEntityExceptionResponse(ex, extensions),
            ArgumentNullException ex => _argumentNullExceptionMapper.SetArgumentNullExceptionResponse(ex, extensions),
            ArgumentException ex => _argumentExceptionMapper.SetArgumentExceptionResponse(ex, extensions),
            HttpRequestException ex => _requestExceptionMapper.SetHttpRequestExceptionResponse(ex, extensions),
            //Polly timeout exception
            TimeoutRejectedException ex => _timeoutRejectedExceptionMapper.SetTimeoutRejectedExceptionResponse(ex, extensions),
            AggregateException ex => _aggregateExceptionMapper.SetAggregateExceptionResponse(ex, extensions),
            _  => _unhandledExceptionMapper.SetDefaultExceptionResponse(exception, extensions)
        };
    }
}
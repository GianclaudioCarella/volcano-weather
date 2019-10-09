using Domain.VolcanoContext.Enums;
using Domain.VolcanoContext.Validations;
using FluentValidation.Results;
using Shared.Commands;
using System;

namespace Domain.VolcanoContext.Commands
{
    public abstract class WeatherCommand : ICommand, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;

        public Guid WeatherId { get; set; }
        public WeatherType Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int PlanetPosition { get; set; }

        public abstract bool IsValid();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}

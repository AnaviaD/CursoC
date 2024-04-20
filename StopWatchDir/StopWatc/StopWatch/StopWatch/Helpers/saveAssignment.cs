using StopWatch.Clases;
using StopWatch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch.Helpers
{
    public class saveAssignment
    {

        private readonly ExamplesContext _dbContext = new ExamplesContext();

        public saveAssignment()
        {
        }

        public assigmentClass obtenemosAssigmentSettings(string nombreAssigment)
        {
            assigmentClass asgment = new assigmentClass();

            try 
            {
                var matchingAssignments = _dbContext.Assignments
                    .Where(a => a.Name != null && a.Name.Contains(nombreAssigment))
                    .FirstOrDefault();

                if (matchingAssignments != null)
                {
                    asgment.id              = matchingAssignments.Id;
                    asgment.name            = matchingAssignments.Name;
                    asgment.difficulty      = matchingAssignments.Difficulty;
                }
                else
                {
                    // No se encontró ningún registro que cumpla con el criterio
                }
            }
            catch { 
            }

            return asgment;

        }

        public void guardamosAssigmentRecord(assigmentClass asiigmentObj, DateTime inicio, DateTime final)
        {
            try
            {
                int tiempoTotalMin = CalcularMinutosTranscurridos(inicio, final);

                // Crear una nueva instancia de AssignmentRecord
                var newRecord = new AssignmentRecord
                {
                    Id              = Guid.NewGuid().ToString(),
                    AssigmentId     = asiigmentObj.id, 
                    InitH           = inicio, 
                    FinishH         = final,
                    TotalTime       = tiempoTotalMin.ToString()

                };

                // Agregar el nuevo registro al contexto
                _dbContext.AssignmentRecords.Add(newRecord);

                // Guardar los cambios en la base de datos
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        

        public assigmentRecordClass obtenerRegistroPorFecha(assigmentClass assigment, DateTime horaInicial)
        {
            assigmentRecordClass assigmentR = new assigmentRecordClass();

            //Agregamos el extra de milisegundos para que quede en el rango
            var registro = _dbContext.AssignmentRecords
                .FirstOrDefault(
                    r => r.AssigmentId == assigment.id && 
                    r.InitH >= horaInicial.AddSeconds(-15) && r.InitH < horaInicial.AddSeconds(15)
                );

            return assigmentR;

        }

        public void updateAssigmentRecord(assigmentRecordClass assigmentRecord, DateTime currentDateTime)
        {
            var registroOriginal = _dbContext.AssignmentRecords.FirstOrDefault(r => r.Id == assigmentRecord.Id);

            registroOriginal.FinishH = currentDateTime;

            _dbContext.SaveChanges();
        }

        public void obtenerFechaHarcodeada()
        {
            DateTime fecha = new DateTime(2024, 4, 18, 19, 47, 36);

            var registro = _dbContext.AssignmentRecords
                .FirstOrDefault(r => r.InitH >= fecha && r.InitH < fecha.AddMinutes(1));

            string finalString = "" + registro.ToString();
        }


        /*
         * ==================================== Helpers ====================================
         * ==================================== Helpers ====================================
         * ==================================== Helpers ====================================
         */

        public static int CalcularMinutosTranscurridos(DateTime fechaInicial, DateTime fechaFinal)
        {
            TimeSpan diferencia = fechaFinal - fechaInicial;
            return (int)diferencia.TotalMinutes;
        }

        private DateTime RoundDateTimeToMinute(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                dateTime.Hour, dateTime.Minute, 0);
        }
    }
}

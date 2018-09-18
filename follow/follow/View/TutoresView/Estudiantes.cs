using System;

namespace follow.View.TutoresView
{
    public class Estudiante
    {
        public string Nombre { get; set; }
        public string Id { get; set; }

        public override string ToString()
        {
            return string.Format("[Estudiante: Nombre={0}");
        }
    }
}
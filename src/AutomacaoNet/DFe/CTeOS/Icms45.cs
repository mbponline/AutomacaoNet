using System;
using AutomacaoNet.DFe.CTeOS.Flags;

namespace AutomacaoNet.DFe.CTeOS
{
    public class Icms45 : ICMS
    {
        public Icms45(Cst cst)
        {
            if (cst == Cst.Cst00 || cst == Cst.Cst90)
                throw new ArgumentException($"CST Inválido para {nameof(Icms45)}");

            Cst = cst;
        }

        public Cst Cst { get; }
    }
}
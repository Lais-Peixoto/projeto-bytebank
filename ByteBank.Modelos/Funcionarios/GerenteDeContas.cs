using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    // Como não é uma abstração, a obrigatoriedade de implementar metodos volta.
    public class GerenteDeContas : FuncionarioAutenticavel
    {
        public GerenteDeContas(string cpf) : base(4000, cpf)
        {
        }
        public override void AumentarSalario()
        {
            Salario *= 1.05;
        }
        internal protected override double GetBonificacao()
        {
            return Salario * 0.25;
        }
    }
}

using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Common
{
    public static class IdentificationValidator
    {
        // Validate ID number
        public static bool IsValidIdNumber(string str, IdentificationType identificationType)
        {
            if(identificationType == IdentificationType.RNC)
                return IsValidRNC(str);

            Regex regex = new Regex(@"^[0-9]{3}-?[0-9]{7}-?[0-9]{1}$");
            if (!regex.IsMatch(str))
            {
                return false;
            }
            str = str.Replace("-", "");
            if (str.All(c => c == '0'))
            {
                return false;
            }
            return CheckDigit(str);
        }

        private static bool CheckDigit(string str)
        {
            int sum = 0;
            for (int i = 0; i < 10; ++i)
            {
                int n = ((i + 1) % 2 != 0 ? 1 : 2) * int.Parse(str[i].ToString());
                sum += n <= 9 ? n : (n % 10) + 1;
            }
            int dig = (10 - (sum % 10)) % 10;

            return dig == int.Parse(str[10].ToString());
        }

        private static bool IsValidRNC(string pRNC)

        {
            int vnTotal = 0;

            int[] digitoMult = new int[8] { 7, 9, 8, 6, 5, 4, 3, 2 };

            string vcRNC = pRNC.Replace("-", "").Replace(" ", "");

            string vDigito = vcRNC.Substring(8, 1);

            if (vcRNC.Length.Equals(9))

                if (!"145".Contains(vcRNC.Substring(0, 1)))

                    return false;

            for (int vDig = 1; vDig <= 8; vDig++)

            {

                int vCalculo = Int32.Parse(vcRNC.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];

                vnTotal += vCalculo;

            }

            if (vnTotal % 11 == 0 && vDigito == "1" || vnTotal % 11 == 1 && vDigito == "1" ||

                (11 - (vnTotal % 11)).Equals(vDigito))

                return true;

            else

                return false;

        }
    }


}

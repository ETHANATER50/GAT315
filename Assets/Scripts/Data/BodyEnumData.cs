using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "BodyEnum", menuName = "Data/Enum/Body")]
    public class BodyEnumData : EnumData
    {
        public enum type
        {
            Static,
            Kindematic,
            Dynamic
        }

        public type value;

        public override int index { get => (int)value; set => this.value = (type)value; }

        public override string[] names => Enum.GetNames(typeof(type));

        public static implicit operator type(BodyEnumData data) { return data.value; }
    }
}

using AYellowpaper;
using UnityEngine;

namespace _App.Game.Core.Commands
{
    public abstract class CommandT<T> : Command
    {
        [SerializeField] protected T value;
        [SerializeField] protected InterfaceReference<IGetT<T>> getValue;

        public void SetValue(T value)
        {
            this.value = value;
        }

        public T ObtainValueFromInterface()
        {
            if (getValue.Value == null)
            {
                return this.value;
            }

            this.value = getValue.Value.GetValue();
            return this.value;
        }

        public void SetValueAndExecute(T value)
        {
            SetValue(value);
            Execute();
        }
    }

    public abstract class CommandT<T1, T2> : Command
    {
        [SerializeField] protected T1 firstValue;
        [SerializeField] protected T2 secondValue;

        [SerializeField] protected InterfaceReference<IGetT<T1>, MonoBehaviour> getFirstValue;
        [SerializeField] protected InterfaceReference<IGetT<T2>, MonoBehaviour> getSecondValue;

        public void SetFirstValue(T1 value)
        {
            this.firstValue = value;
        }

        public void SetSecondValue(T2 value)
        {
            this.secondValue = value;
        }

        public void ObtainValuesFromInterface()
        {
            if (getFirstValue.Value != null)
            {
                this.firstValue = getFirstValue.Value.GetValue();
            }

            if (getSecondValue.Value != null)
            {
                this.secondValue = getSecondValue.Value.GetValue();
            }
        }

        public void SetValuesAndExecute(T1 firstValue, T2 secondValue)
        {
            this.firstValue = firstValue;
            this.secondValue = secondValue;
            Execute();
        }
    }

    public abstract class CommandT<T1, T2, T3> : Command
    {
        [SerializeField] protected T1 firstValue;
        [SerializeField] protected T2 secondValue;
        [SerializeField] protected T3 thirdValue;

        [SerializeField] protected InterfaceReference<IGetT<T1>, MonoBehaviour> getFirstValue;
        [SerializeField] protected InterfaceReference<IGetT<T2>, MonoBehaviour> getSecondValue;
        [SerializeField] protected InterfaceReference<IGetT<T3>, MonoBehaviour> getThirdValue;

        public void ObtainValuesFromInterface()
        {
            if (getFirstValue.Value != null)
            {
                this.firstValue = getFirstValue.Value.GetValue();
            }

            if (getSecondValue.Value != null)
            {
                this.secondValue = getSecondValue.Value.GetValue();
            }

            if (getThirdValue.Value != null)
            {
                this.thirdValue = getThirdValue.Value.GetValue();
            }
        }

        public void SetValuesAndExecute(T1 firstValue, T2 secondValue, T3 thirdValue)
        {
            this.firstValue = firstValue;
            this.secondValue = secondValue;
            this.thirdValue = thirdValue;
            Execute();
        }
    }
}
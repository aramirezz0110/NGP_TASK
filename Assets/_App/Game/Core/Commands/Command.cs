using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace _App.Game.Core.Commands
{
    public abstract class Command : MonoBehaviour, ICommand
    {
        private const bool EnableLogs = false;
        private const string GeneralLog = "Command {0} on {1}: {2}";
        private const string StartLog = "START";
        private const string SuccessLog = "SUCCESS";
        private const string FailLog = "FAIL";
        private const string FinishLog = "FINISH";

        [SerializeField] private UnityEvent _onStart = default;
        [SerializeField] private UnityEvent _onSuccess = default;
        [SerializeField] private UnityEvent _onFail = default;
        [SerializeField] private UnityEvent _onFinish = default;

        protected CancellationTokenSource cancellationTokenSource = new();

        public void Execute()
        {
            AwaitableExecute().AttachExternalCancellation(cancellationTokenSource.Token);
        }

        private void OnDestroy()
        {
            cancellationTokenSource?.Cancel();
        }

        public async UniTask AwaitableExecute()
        {
            Log(StartLog);
            _onStart?.Invoke();
            try
            {
                await ExecuteInternal().AttachExternalCancellation(cancellationTokenSource.Token);
                Log(SuccessLog);
                _onSuccess?.Invoke();
            }
            catch (ExpectedException)
            {
                Log(FailLog);
                _onFail?.Invoke();
            }
            catch (OperationCanceledException exception)
            {
                Debug.LogWarning(exception);
                Log(FailLog);
                _onFail?.Invoke();
            }
            catch (Exception)
            {
                Log(FailLog);
                _onFail?.Invoke();
                throw;
            }

            Log(FinishLog);
            _onFinish?.Invoke();
        }

        protected abstract UniTask ExecuteInternal();

        private void Log(string state)
        {
#pragma warning disable CS0162
            if (EnableLogs)
            {
                string formattedMessage = string.Format(GeneralLog, GetType().Name, gameObject.name, state);
                Debug.Log(formattedMessage, gameObject);
            }
#pragma warning restore CS0162
        }

        public class ExpectedException : Exception
        {
            public ExpectedException() { }
            public ExpectedException(string message) : base(message) { }
            public ExpectedException(string message, Exception innerException) : base(message, innerException) { }
        }
    }
}
using System;
using LightBDD.Naming;
using LightBDD.Results;
using LightBDD.Results.Implementation;

namespace LightBDD
{
	internal class Step
	{
		private readonly Action _action;
		private readonly Func<Type, ResultStatus> _mapping;
		private readonly StepResult _result;
		public IStepResult Result { get { return _result; } }

		public Step(Action action, int stepNumber, Func<Type, ResultStatus> mapping)
		{
			_action = action;
			_mapping = mapping;
			_result = new StepResult(stepNumber, NameFormatter.Format(action.Method.Name), ResultStatus.NotRun);
		}

		public void Invoke()
		{
			try
			{
				_action();
				_result.SetStatus(ResultStatus.Passed);
			}
			catch (Exception e)
			{
				_result.SetStatus(_mapping(e.GetType()), e.Message);
				throw;
			}
		}
	}
}
using System;
using BuddyTween.Enums;

namespace BuddyTween.Algorithms
{
    public static class AlgorithmSelector
    {
	    public delegate float Algorithm(float start, float end, float t);
	    
        public static Algorithm FromType(EaseType type)
        {
	        return type switch
	        {
		        EaseType.Linear => Linear.Eval,
		        EaseType.Spring => Spring.Eval,
		        EaseType.QuadIn => Quadratic.In,
		        EaseType.QuadOut => Quadratic.Out,
		        EaseType.QuadInOut => Quadratic.InOut,
		        EaseType.CubicIn => Cubic.In,
		        EaseType.CubicOut => Cubic.Out,
		        EaseType.CubicInOut => Cubic.InOut,
		        EaseType.BounceIn => Bounce.In,
		        EaseType.BounceOut => Bounce.Out,
		        EaseType.ElasticIn => Elastic.In,
		        EaseType.ElasticOut => Elastic.Out,
		        EaseType.ElasticInOut => Elastic.InOut,
		        EaseType.SineIn => Sinusoidal.In,
		        EaseType.SineOut => Sinusoidal.Out,
		        EaseType.SineInOut => Sinusoidal.InOut,
		        EaseType.ExpoIn => Exponential.In,
		        EaseType.ExpoOut => Exponential.Out,
		        EaseType.ExpoInOut => Exponential.InOut,
		        EaseType.CircIn => Circular.In,
		        EaseType.CircOut => Circular.Out,
		        EaseType.CircInOut => Circular.InOut,
		        EaseType.BackIn => Back.In,
		        EaseType.BackOut => Back.Out,
		        EaseType.BackInOut => Back.InOut,
		        _ => throw new Exception($"Ease type {type} not available.")
	        };
        }
    }
}
namespace No1.Commons;

using System;
using System.Threading;

public sealed class ResettableLazy<T>
{
	private readonly Func<T> factory;
	private readonly Lock @lock = new();

	private Lazy<T> lazy;

	public ResettableLazy(Func<T> factory) {
		this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
		this.lazy = this.CreateLazy();
	}

	public T Value => this.lazy.Value;

	public bool IsValueCreated => this.lazy.IsValueCreated;

	public void Reset() {
		lock (this.@lock) {
			this.lazy = this.CreateLazy();
		}
	}

	private Lazy<T> CreateLazy() {
		return new Lazy<T>(
			this.factory,
			LazyThreadSafetyMode.ExecutionAndPublication
		);
	}
}
namespace activity10
{
    /// <summary>
    /// Computes the addition of the square values of part of a vector
    /// </summary>
    internal class Worker
    {
        /// <summary>
        /// The vector whose modulus is going to be computed.
        /// </summary>
        private BitcoinValueData[] data;

        /// <summary>
        /// Indices of the vector indicating the elements to be used in the computation.
        /// Both fromIndex and toIndex are included in the process.
        /// </summary>
        private int fromIndex,
            toIndex;

        /// <summary>
        /// The result of the computation
        /// </summary>
        private double result;
        private int value;

        internal double Result
        {
            get { return this.result; }
        }

        internal Worker(BitcoinValueData[] data, int value, int fromIndex, int toIndex)
        {
            this.data = data;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
            this.value = value;
        }

        internal void Compute()
        {
            this.result = 0;
            for (int i = this.fromIndex; i <= this.toIndex; i++)
                if (this.data[i].Value > this.value)
                    this.result++;
        }
    }
}

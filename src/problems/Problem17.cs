using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
	public class Problem17 : ProblemBase
	{
		public Problem17 ()
		{
		}

		private IDictionary<int, string> _dict = new Dictionary<int, string>{
			{0,"zero"},
			{1,"one"},
			{2,"two"},
			{3,"three"},
			{4,"four"},
			{5,"five"},
			{6,"six"},
			{7,"seven"},
			{8,"eight"},
			{9,"nine"},
			{10,"ten"},
			{11,"eleven"},
			{12,"twelve"},
			{13,"thirteen"},
			{14,"fourteen"},
			{15,"fifteen"},
			{16,"sixteen"},
			{17,"seventeen"},
			{18,"eighteen"},
			{19,"nineteen"},
			{20,"twenty"},
			{30,"thirty"},
			{40,"forty"},
			{50,"fifty"},
			{60,"sixty"},
			{70,"seventy"},
			{80,"eighty"},
			{90,"ninety"},
			{100,"hundred"},
			{1000,"thousand"}
		};

		#region implemented abstract members of ProblemBase

		public override string Solve ()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 1; i<=1000; i++)
			{
				sb.Append(WriteNumber(i));
			}
			sb = sb.Replace(" ", string.Empty);
			Console.WriteLine(sb.ToString());
			return sb.ToString().Length.ToString();
		}

		private string WriteNumber (int num)
		{
//			if (_dict.ContainsKey (num))
//			{
//				return _dict [num];
//			} else
//			{
				int x = num;
				int numThousands = x / 1000;
				x = x % 1000;
				int numHundreds = x / 100;
				x = x % 100;
				int numTens = x / 10;
				x = x % 10;
				StringBuilder sb = new StringBuilder();
				if(numThousands > 0){
					sb.Append(_dict[numThousands]).Append(" thousand");
				}
				if(numHundreds > 0){
					sb.Append(_dict[numHundreds]).Append(" hundred");
					if(numTens > 0 || x > 0){
						sb.Append(" and ");
					}
				}
				if(numTens == 1){
					int teen = 10 + x;
					sb.Append(_dict[teen]);
				}else if(numTens > 1){
					int temp = numTens * 10;
					sb.Append(_dict[temp]).Append(" ");	
				}
				if(x > 0 && numTens != 1){
					sb.Append(_dict[x]);
				}
				var s =sb.ToString();
				return s;
//			}
		}

		public override int ProblemNumber
		{
			get {
				return 17;
			}
		}

		#endregion
	}
}


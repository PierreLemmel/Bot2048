using Bot2048.Model;
using NUnit.Framework;
using System.Collections.Generic;

using static Bot2048.Model.CellValue;

namespace Bot2048.Logic.Test
{
    public class GameAnalyzerTestSource
    {
        public static IEnumerable<TestCaseData> TestCases_CanMoveLeft_WhenRowIsFilled_And_NoConsecutiveValues
        {
            get
            {
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Value2, Value32, Value4, Value8},
                    { Empty , Empty  , Empty , Empty },
                    { Empty , Empty  , Empty , Empty },
                    { Empty , Empty  , Empty , Empty }
                }));
            }
        }

        public static IEnumerable<TestCaseData> TestCases_CanMoveLeft_WhenRowIsFilled_And_ConsecutiveValues
        {
            get
            {
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Value4, Value4, Value32, Value8 },
                    { Empty , Empty , Empty  , Empty  },
                    { Empty , Empty , Empty  , Empty  },
                    { Empty , Empty , Empty  , Empty  },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Value32, Value4, Value4, Value8 },
                    { Empty  , Empty , Empty , Empty  },
                    { Empty  , Empty , Empty , Empty  },
                    { Empty  , Empty , Empty , Empty  },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Value32, Value8, Value4, Value4 },
                    { Empty  , Empty , Empty , Empty  },
                    { Empty  , Empty , Empty , Empty  },
                    { Empty  , Empty , Empty , Empty  },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Value32, Value4, Value4, Value4 },
                    { Empty  , Empty , Empty , Empty  },
                    { Empty  , Empty , Empty , Empty  },
                    { Empty  , Empty , Empty , Empty  },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Value4, Value4, Value4, Value4 },
                    { Empty , Empty , Empty , Empty  },
                    { Empty , Empty , Empty , Empty  },
                    { Empty , Empty , Empty , Empty  },
                }));
            }
        }

        public static IEnumerable<TestCaseData> TestCases_CanMoveLeft_WhenRowContainsOneEmptyCells_NotAtTheMostRight
        {
            get
            {
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Empty, Value4, Value32, Value8 },
                    { Empty, Empty , Empty  , Empty  },
                    { Empty, Empty , Empty  , Empty  },
                    { Empty, Empty , Empty  , Empty  },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Value2, Empty, Value32, Value8 },
                    { Empty , Empty, Empty  , Empty  },
                    { Empty , Empty, Empty  , Empty  },
                    { Empty , Empty, Empty  , Empty  },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Value2, Value4, Empty, Value8 },
                    { Empty , Empty , Empty, Empty  },
                    { Empty , Empty , Empty, Empty  },
                    { Empty , Empty , Empty, Empty  },
                }));
            }
        }

        public static IEnumerable<TestCaseData> TestCases_CanMoveLeft_WhenRowContains2Or3EmptyCells
        {
            get
            {
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Empty, Empty, Value32, Value8 },
                    { Empty, Empty, Empty  , Empty  },
                    { Empty, Empty, Empty  , Empty  },
                    { Empty, Empty, Empty  , Empty  },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Empty, Value4, Empty, Value8 },
                    { Empty, Empty , Empty, Empty  },
                    { Empty, Empty , Empty, Empty  },
                    { Empty, Empty , Empty, Empty  },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Empty, Value4, Value32, Empty },
                    { Empty, Empty , Empty  , Empty },
                    { Empty, Empty , Empty  , Empty },
                    { Empty, Empty , Empty  , Empty },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Value2, Empty, Empty, Value8 },
                    { Empty , Empty, Empty, Empty  },
                    { Empty , Empty, Empty, Empty  },
                    { Empty , Empty, Empty, Empty  },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Value2, Empty, Value32, Empty },
                    { Empty , Empty, Empty  , Empty },
                    { Empty , Empty, Empty  , Empty },
                    { Empty , Empty, Empty  , Empty },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Value2, Value4, Empty, Empty },
                    { Empty , Empty , Empty, Empty },
                    { Empty , Empty , Empty, Empty },
                    { Empty , Empty , Empty, Empty },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Empty, Empty, Empty, Value8 },
                    { Empty, Empty, Empty, Empty  },
                    { Empty, Empty, Empty, Empty  },
                    { Empty, Empty, Empty, Empty  },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Empty, Empty, Value32, Empty },
                    { Empty, Empty, Empty  , Empty },
                    { Empty, Empty, Empty  , Empty },
                    { Empty, Empty, Empty  , Empty },
                }));
                yield return new TestCaseData(new Grid(new CellValue[4, 4]
                {
                    { Value2, Empty, Empty, Empty },
                    { Empty , Empty, Empty, Empty },
                    { Empty , Empty, Empty, Empty },
                    { Empty , Empty, Empty, Empty },
                }));
            }
        }
    }
}

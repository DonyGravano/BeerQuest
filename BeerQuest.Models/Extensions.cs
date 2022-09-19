namespace BeerQuest.Models;

public static class Extensions
{
    public static string ToDbColumn(this RatingType ratingType)
    {
        switch (ratingType)
        {
            case RatingType.Null:
                break;
            case RatingType.Beer:
                return "stars_beer";
            case RatingType.Atmosphere:
                return "stars_atmosphere";
            case RatingType.Amenities:
                return "stars_amenities";
            case RatingType.Value:
                return "stars_value";
            default:
                throw new ArgumentOutOfRangeException(nameof(ratingType), ratingType, null);
        }

        return string.Empty;
    }

    public static string ToOperatorString(this ComparisonOperator ratingType)
    {
        switch (ratingType)
        {
            case ComparisonOperator.NotEqual:
                return "<>";
            case ComparisonOperator.Equal:
                return "=";
            case ComparisonOperator.GreaterThan:
                return ">";
            case ComparisonOperator.GreaterThanOrEqualTo:
                return ">=";
            case ComparisonOperator.LessThan:
                return "<";
            case ComparisonOperator.LessThanOrEqualTo:
                return "<=";
            default:
                throw new ArgumentOutOfRangeException(nameof(ratingType), ratingType, null);
        }
    }
}
public interface IRatingList
{
 int Count { get; }
 void AddFirst(RatingRecord value);
 void AddAtIndex(RatingRecord value, int index);
 bool RemoveById(int recordId);
 RatingRecord? FindById(int recordId);
 RatingRecord GetAt(int position);
}

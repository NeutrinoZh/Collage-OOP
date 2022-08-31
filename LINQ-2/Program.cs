namespace Program {
    class Program {
        private static void Task1() {
            Console.WriteLine("Task 1");

            List<string> strs = new List<string>() { "16436", "436346", "436737", "7574", "375389", "373831" };

            Console.WriteLine("To numbers:");

            var numbers = from str in strs
                          select Int32.Parse(str);
            foreach (var item in numbers) {
                Console.WriteLine(item);
            }

            Console.WriteLine("To char arrays:");

            var chars = strs.SelectMany(str => str.ToCharArray(0, str.Length));
            foreach (var item in chars) {
                Console.WriteLine(item);
            }

            Console.WriteLine("To anonymous object:");
            var objects = strs.Select(str => new { str });
            foreach (var item in objects) {
                Console.WriteLine(item);
            }
        }

        private record class MusicGroup(Guid id, string name);
        private record class Member(Guid id, Guid groupId, string name);
        private static void Task2() {
            Console.WriteLine("Task 2");

            List<MusicGroup> groups = new List<MusicGroup>(){
                new MusicGroup(Guid.NewGuid(), "Group 1"),
                new MusicGroup(Guid.NewGuid(), "Group 2"),
                new MusicGroup(Guid.NewGuid(), "Group 3")
            };

            List<Member> mebmers = new List<Member>(){
                new Member(Guid.NewGuid(), groups[2].id, "Member 1"),
                new Member(Guid.NewGuid(), groups[1].id, "Member 2"),
                new Member(Guid.NewGuid(), groups[0].id, "Member 3"),
                new Member(Guid.NewGuid(), groups[1].id, "Member 4"),
                new Member(Guid.NewGuid(), groups[1].id, "Member 5"),
                new Member(Guid.NewGuid(), groups[2].id, "Member 6"),
                new Member(Guid.NewGuid(), groups[0].id, "Member 7")
            };

            var concert = from member in mebmers
                          join _group in groups on member.groupId equals _group.id
                          select new { id = member.id, groupId = _group.id, name = member.name, groupName = _group.name };

            foreach (var item in concert)
                Console.WriteLine($"{item.id}, {item.groupId}, {item.name}, {item.groupName}");
        }

        private static void Task3() {
            Console.WriteLine("Task 3");

            List<string> singers1 = new List<string>(){
                "1", "2", "3", "4"
            };

            List<string> singers2 = new List<string>(){
                "3", "4", "5", "6"
            };

            Console.WriteLine("By Union:");

            var union = singers1.Union(singers2);
            foreach (var item in union)
                Console.WriteLine(item);

            Console.WriteLine("By Concat with Distinct:");

            var concat = singers1.Concat(singers2).Distinct();
            foreach (var item in concat)
                Console.WriteLine(item);
        }

        private static void Task4() {
            Console.WriteLine("Task 4");

            List<uint> numbers = new List<uint>(){ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; 

            Console.WriteLine("Take(3):");

            var take = numbers.Take(3);
            foreach (var item in take)
                Console.WriteLine(item);

            Console.WriteLine("TakeWhile(item != 5):");

            var takeWhile = numbers.TakeWhile(item => item != 5);
            foreach (var item in takeWhile)
                Console.WriteLine(item);
        }

        public static void Main(string[] args) {
            Task1();
            Task2();
            Task3();
            Task4();
        }
    }
}
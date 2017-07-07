class WordSplitter 
 
 include Enumerable 
 
 attr_accessor :string 
 
 def each 
 string.split(" ").each do |word| 
 yield word 
 end 
 end 
 
end

splitter = WordSplitter.new 
splitter.string = "salad beefcake corn beef pasta beefy" 
splitter.find_all { |word| word.include?("beef") } 
splitter.reject { |word| word.include?("beef") } 
splitter.map { |word| word.capitalize } 
splitter.count 
splitter.find { |word| word.include?("beef") } 
splitter.first 
splitter.group_by { |word| word.include?("beef") } 
splitter.max_by { |word| word.length } 
splitter.to_a
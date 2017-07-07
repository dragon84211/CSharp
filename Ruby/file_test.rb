lines = []
relevant_lines = []
File.open("C:/temp/testfile.txt") do |testfile| 
    lines = testfile.readlines 
end

=begin
lines.each do |line|
    if line.include?("Truncated")
        relevant_lines << line
    end
end
=end

relevant_lines = lines.find_all{|line| line.include?("Truncated")} #Same as above
reviews = relevant_lines.reject { |line| line.include?("--") }
puts reviews
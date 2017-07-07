prices = [2.99, 25.00, 9.99]
p prices

#####
puts "-----"
mix = ["one", 2, 'three', Time.new]
p mix

#####
puts "-----"
letters = ["b", "c", "b", "a"]
letters.pop
p letters

#####The each method loops through each item in the array and yields it to the block
puts "-----"
["a", "b", "c"].each { |param| puts param }
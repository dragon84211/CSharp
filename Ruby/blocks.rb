def my_method(&my_block) #this method takes in a block
    puts "In a method.  About to invoke your block."
    my_block.call
    puts "We're back in the method"
end

my_method do # start of block call
    puts "We're in the block"
end
puts "---"
my_method {puts "Same as above"} #should only be used for one liners

######Passing stuff from method into block
puts "-----"
def give(&my_block)
    my_block.call("2 turtle doves", "1 partridge")
end

give do |present1, present2|
    puts "My method gave me"
    puts present1, present2
end

##### same as above
puts "-----"
def give
    yield "2 turtle doves", "1 partridge"
end

give do |present1, present2|
    puts "My method gave me"
    puts present1, present2
end

#####The each method loops through each item in the array and yields it to the block
puts "-----"
["a", "b", "c"].each { |param| puts param }

#####Passing a variable and a block to a method
puts "-----"
def foo_m(number, &my_block)
    puts number
    yield number
end

foo_m 10 do |num|
    puts "something to go with the number #{num}"
end

foo_m 10 {|num| puts "same as above #{num}"}
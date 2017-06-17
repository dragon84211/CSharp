puts "Welcome to 'Get My Number!'"
print "What's your name? "

input = gets.chomp

puts "Welcome, #{input}!"

#p input #reveals that the enter has a new line if "chomp" isn't used

puts "I've got a random number between 1 and 100"
puts "Can you guess it?"
target = rand(100) + 1

num_guesses = 0
guessed_it = false

while num_guesses < 10 && guessed_it == false

  puts "You've got #{10 -num_guesses} guesses left."
  print "Make a guess: "
  guess = gets.chomp.to_i
  
  num_guesses +=1
  
  if guess < target
    puts "Guess too low"
  elsif guess > target
    puts "Guess too high"
  elsif guess == target
    puts "You guessed my number in #{num_guesses} tries"
    guessed_it = true
  end
end
  
unless guessed_it #also same as {if !guessed_it} and {if not guessed_it}
puts "You lost.  My number was #{target}"
end

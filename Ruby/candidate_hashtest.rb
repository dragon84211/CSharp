class Candidate 
    attr_accessor :name, :age, :occupation, :hobby, :birthplace 
    #A mix of no defaults, and with default params in method params as hash.  
    #Benefit of this format is this will let you know if you have a typo
    def initialize(name, age:, occupation:, hobby: nil, birthplace: "Sleepy Creek") 
        self.name = name 
        self.age = age 
        self.occupation = occupation 
        self.hobby = hobby 
        self.birthplace = birthplace 
    end 
end

p Candidate.new("Carl Barnes", age: 49, occupation: "Attorney")

##### Basic Hash
basic_hash = {:M => "Monday", :T => "Tuesday"}
basic_hash_clone = {M: "Monday", T: "Tuesday"}
basic_hash_notclone = {"M" => "Monday", "T" => "Tuesday"}

p basic_hash
p basic_hash_clone
p basic_hash_notclone

if basic_hash == basic_hash_clone
    puts "true"
else   
    puts "false"
end

##### Hash Assignment with Defaults (not necessary with numbers)
class CelestialBody 
    attr_accessor :type, :name 
end

#So basically the "new" method can take in a block
bodies = Hash.new do |hash, key| 
    body = CelestialBody.new 
    body.type = "planet" 
    hash[key] = body 
    #body #Optional. Returns regardless given line above 
end

bodies['Mars'].name = 'Mars' 
bodies['Europa'].name = 'Europa' 
bodies['Europa'].type = 'moon' 
bodies['Venus'].name = 'Venus' 

#can also be done this way, but you need to specify the object each time...
bodies['Pluto'] = CelestialBody.new
bodies['Pluto'].name = "Pluto"

p bodies['Mars'] 
p bodies['Europa'] 
p bodies['Venus']
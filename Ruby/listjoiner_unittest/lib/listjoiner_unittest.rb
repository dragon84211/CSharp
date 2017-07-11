class ListWithCommas 
    attr_accessor :items 
    def join 
#Commented out to force assertions to fail
=begin
        if items.length == 1 
            return items[0]
        elsif items.length == 2 
            return "#{items[0]} and #{items[1]}" 
        end
=end
        last_item = "and #{items.last}" 
        other_items = items.slice(0, items.length - 1).join(', ') 
        "#{other_items}, #{last_item}" 
    end 
end 
 
three_subjects = ListWithCommas.new 
three_subjects.items = ['my parents', 'a rodeo clown', 'a prize bull'] 
puts "A photo of #{three_subjects.join}"
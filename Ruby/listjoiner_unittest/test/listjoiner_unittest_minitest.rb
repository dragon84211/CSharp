#ruby -I C:\Users\drago\Documents\`Local\GitRepo\Ruby\listjoiner_unittest\lib C:\Users\drago\Documents\`Local\GitRepo\Ruby\listjoiner_unittest\test\listjoiner_unittest_minitest.rb

require 'minitest/autorun' 
require 'listjoiner_unittest' 
 
class TestListWithCommas < Minitest::Test 
    attr_accessor :list #For fun...this makes "self.list" work in the last example

    def setup 
        @list = ListWithCommas.new #List has to be an instance var.  All mentions of list below updated to use instance var
    end 

    def teardown
        @list = nil #Not needed.  Just playing around with using teardown after each test
    end

    def test_it_prints_one_word_alone 
        #list = ListWithCommas.new #No longer needed due to the standard "setup" method
        @list.items = ['apple'] 
        #assert('apple' == list.join, "Return value didn't equal 'apple'") #Add a message manually
        assert_equal('apple', @list.join)
    end 

    def test_it_joins_two_words_with_and 
        #list = ListWithCommas.new 
        @list.items = ['apple', 'orange'] 
        #assert('apple and orange' == list.join) 
        assert_equal('apple and orange', @list.join)
    end 
    
    def test_it_joins_three_words_with_commas 
        #list = ListWithCommas.new 
        @list.items = ['apple', 'orange', 'pear'] 
        #assert('apple, orange, and pear' == list.join)
        assert_equal('apple, orange, and pear', self.list.join) 
    end 
 
end
#
# Be sure to run `pod lib lint MessagingInAppWrapper.podspec' to ensure this is a
# valid spec before submitting.
#
# Any lines starting with a # are optional, but their use is encouraged
# To learn more about a Podspec see https://guides.cocoapods.org/syntax/podspec.html
#

Pod::Spec.new do |s|
  s.name             = 'MessagingInAppWrapper'
  s.version          = '0.1.0'
  s.summary          = 'A short description of MessagingInAppWrapper.'
  s.homepage         = 'https://github.com/salesforce/MessagingInAppWrapper'
  s.license          = { :type => 'MIT', :file => 'LICENSE' }
  s.author           = { 'Jeremy Wright' => 'jeremy.wright@salesforce.com' }
  s.source           = { "git": "local source", tag: "0.1.0" }

  s.ios.deployment_target = '14.0'

  s.source_files = 'MessagingInAppWrapper/Classes/**/*'

  s.dependency 'Messaging-InApp-Core', '~> 1.0'
end
